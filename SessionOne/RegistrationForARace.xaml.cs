using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class RegistrationForARace : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();

        int money;
        bool check2 = false;
        bool check3 = false;
        string email = SaveThings.email;
        string ID_Charity = "";

        public RegistrationForARace()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            charityTableAdapter.Fill(dataSet.Charity);
            registrationTableAdapter.Fill(dataSet.Registration);
            userTableAdapter.Fill(dataSet.User);
            racerTableAdapter.Fill(dataSet.Racer);

            cbCharity.ItemsSource = dataSet.Charity.DefaultView;
            cbCharity.DisplayMemberPath = "Charity_Name";
            cbCharity.SelectedValuePath = "ID_Charity";
            cbCharity.SelectedIndex = 0;
        }

        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void btnBackToRacerMenu_Click(object sender, RoutedEventArgs e)
        {
            RacerMenu racerMenu = new RacerMenu();
            racerMenu.Show();
            Hide();
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string ID_User = "";
            string ID_Racer = "";

            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            if (typeOne.IsChecked == false && typeTwo.IsChecked == false && typeThree.IsChecked == false)
                MessageBox.Show("По крайней мере 1 вид гонки должен быть выбран");
            else if (decimal.Parse(tbPayment.Text) == 0 || string.IsNullOrEmpty(tbPayment.Text))
                MessageBox.Show("Вы не можете пожертвовать $0");
            else
            {
                for (int i = 0; i < dataSet.Tables["User"].Rows.Count; i++)
                {
                    if (email == dataSet.Tables["User"].Rows[i]["Email"].ToString())
                        ID_User = dataSet.Tables["User"].Rows[i]["ID_User"].ToString();
                }
                for (int i = 0; i < dataSet.Tables["Racer"].Rows.Count; i++)
                {
                    if (ID_User == dataSet.Tables["Racer"].Rows[i]["ID_User"].ToString())
                    {
                        ID_Racer = dataSet.Tables["Racer"].Rows[i]["ID_Racer"].ToString();
                        break;
                    }
                }
                for (int j = 0; j < dataSet.Tables["Charity"].Rows.Count; j++)
                {
                    if (cbCharity.Text == dataSet.Tables["Charity"].Rows[j]["Charity_Name"].ToString())
                    {
                        ID_Charity = dataSet.Tables["Charity"].Rows[j]["ID_Сharity"].ToString();
                        break;
                    }
                }

                string event_type1 = "2.5KM";
                string event_type2 = "4KM";
                string event_type3 = "6.5KM";

                if (typeOne.IsChecked == true)
                    registrationTableAdapter.Insert(int.Parse(ID_Racer), Convert.ToDateTime(dateNow), 1, decimal.Parse(tbNeedToPay.Text), int.Parse(ID_Charity), decimal.Parse(tbPayment.Text), event_type1);
                if (typeTwo.IsChecked == true)
                    registrationTableAdapter.Insert(int.Parse(ID_Racer), Convert.ToDateTime(dateNow), 1, decimal.Parse(tbNeedToPay.Text), int.Parse(ID_Charity), decimal.Parse(tbPayment.Text), event_type2); 
                if (typeThree.IsChecked == true)
                    registrationTableAdapter.Insert(int.Parse(ID_Racer), Convert.ToDateTime(dateNow), 1, decimal.Parse(tbNeedToPay.Text), int.Parse(ID_Charity), decimal.Parse(tbPayment.Text), event_type3);

                AcceptRegistration acceptRegistration = new AcceptRegistration();
                acceptRegistration.Show();
                Hide();
            }
        }

        private void tbPayment_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        #region Choice:
        private void typeOne_Click(object sender, RoutedEventArgs e)
        {
            if (typeOne.IsChecked == true)
                money += 25;
            else
                money -= 25;
            tbNeedToPay.Text = money.ToString();
        }
        private void typeTwo_Click(object sender, RoutedEventArgs e)
        {
            if (typeTwo.IsChecked == true)
                money += 40;
            else
                money -= 40;
            tbNeedToPay.Text = money.ToString();
        }
        private void typeThree_Click(object sender, RoutedEventArgs e)
        {
            if (typeThree.IsChecked == true)
                money += 65;
            else
                money -= 65;
            tbNeedToPay.Text = money.ToString();
        }

        private void RadioTypeOne_Click(object sender, RoutedEventArgs e)
        {
            if (check2)
            {
                money -= 30;
                check2 = false;
            }

            if (check3)
            {
                money -= 50;
                check3 = false;
            }
            tbNeedToPay.Text = money.ToString();
        }
        private void RadioTypeTwo_Click(object sender, RoutedEventArgs e)
        {
            if (check3)
            {
                money -= 50;
                check3 = false;
            }
            money += 30;
            check2 = true;
            tbNeedToPay.Text = money.ToString();
        }
        private void RadioTypeThree_Click(object sender, RoutedEventArgs e)
        {
            if (check2)
            {
                money -= 30;
                check2 = false;
            }
            money += 50;
            check3 = true;
            tbNeedToPay.Text = money.ToString();
        }
        #endregion


    }
}