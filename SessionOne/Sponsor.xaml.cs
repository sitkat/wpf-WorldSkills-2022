using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class Sponsor : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        SponsorshipTableAdapter sponsorshipTableAdapter = new SponsorshipTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        Racer_ViewTableAdapter racer_ViewTableAdapter = new Racer_ViewTableAdapter();

        string strCharity = "";
        public Sponsor()
        {
            InitializeComponent();

            sponsorshipTableAdapter.Fill(dataSet.Sponsorship);
            registrationTableAdapter.Fill(dataSet.Registration);
            racerTableAdapter.Fill(dataSet.Racer);
            charityTableAdapter.Fill(dataSet.Charity);
            racer_ViewTableAdapter.Fill(dataSet.Racer_View);

            RacerCB.ItemsSource = dataSet.Racer_View.DefaultView;
            RacerCB.DisplayMemberPath = "AllInformation";
            RacerCB.SelectedValuePath = "ID_Racer";
            RacerCB.SelectedIndex = 0;

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void MoreMoney_Click(object sender, RoutedEventArgs e)
        {
            decimal money = decimal.Parse(PaymentTB.Text) + 10;
            PaymentTB.Text = money.ToString();
        }

        private void PaymentTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LessMoney_Click(object sender, RoutedEventArgs e)
        {
            decimal money = decimal.Parse(PaymentTB.Text);

            if (money >= 10)
            {
                money = money - 10;
                PaymentTB.Text = money.ToString();
            }
        }


        private void CarNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CarNumberTB.Text.Length == 4 || CarNumberTB.Text.Length == 9 || CarNumberTB.Text.Length == 14)
            {
                CarNumberTB.Text = CarNumberTB.Text + " ";
                CarNumberTB.SelectionStart = CarNumberTB.Text.Length;
            }

        }

        private void CarNumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CardMonthtTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CardYearTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CVCTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateCard = new DateTime(int.Parse(CardYearTB.Text), int.Parse(CardMonthtTB.Text), 1, 0, 0, 0);
                DateTime dateNow = DateTime.Now;
                TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0);
                if (string.IsNullOrEmpty(CardMonthtTB.Text) || string.IsNullOrEmpty(CardYearTB.Text) || string.IsNullOrEmpty(CardOwnerTB.Text) || string.IsNullOrEmpty(NameTB.Text) || string.IsNullOrEmpty(CVCTB.Text))
                    MessageBox.Show("Заполните все поля!");
                else if (CarNumberTB.Text.Length != 19)
                {
                    MessageBox.Show("Некорректный номер банковской карты!");
                    CarNumberTB.Text = "";
                }
                else if ((dateCard - dateNow) < timeSpan)
                {
                    MessageBox.Show("Некорректная дата!");
                    CardYearTB.Text = "";
                    CardMonthtTB.Text = "";
                }
                else if (CVCTB.Text.Length != 3)
                {
                    MessageBox.Show("Некорректный CVC!");
                    CVCTB.Text = "";
                }
                else if (decimal.Parse(PaymentTB.Text) == 0)
                    MessageBox.Show("Минимальная сумма пожертвования: $1!");
                else
                {
                    sponsorshipTableAdapter.Insert(NameTB.Text, decimal.Parse(PaymentTB.Text), int.Parse(RacerCB.SelectedValue.ToString()));
                    SaveThings.racerName = RacerCB.Text;
                    SaveThings.charName = CharityName.Text;
                    SaveThings.payment = PaymentTB.Text;

                    AcceptSponsor acceptSponsor = new AcceptSponsor();
                    acceptSponsor.Show();
                    Hide();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CardOwnerTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PaymentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            PaymentSumm.Content = "$ " + PaymentTB.Text;
        }

        private void RacerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int j = 0; j < dataSet.Tables["Registration"].Rows.Count; j++)
            {
                if (RacerCB.SelectedValue.ToString() == dataSet.Tables["Registration"].Rows[j]["ID_Racer"].ToString())
                {
                    strCharity = dataSet.Tables["Registration"].Rows[j]["ID_Charity"].ToString();
                    PaymentTB.Text = (decimal.Parse(dataSet.Tables["Registration"].Rows[j]["Cost"].ToString())).ToString();
                    PaymentSumm.Content = "$ " + PaymentTB.Text;
                }
            }

            for (int i = 0; i < dataSet.Tables["Charity"].Rows.Count; i++)
            {
                if (strCharity == dataSet.Tables["Charity"].Rows[i]["ID_Сharity"].ToString())
                {
                    string charityName = dataSet.Tables["Charity"].Rows[i]["Charity_Name"].ToString();
                    CharityName.Text = charityName;
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NameTB.Text = "";
            CardOwnerTB.Text = "";
            CarNumberTB.Text = "";
            CardMonthtTB.Text = "";
            CardYearTB.Text = "";
            CVCTB.Text = "";
            PaymentTB.Text = "0";
        }
    }
}
