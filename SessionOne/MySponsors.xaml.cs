using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class MySponsors : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        MySponsorViewTableAdapter mySponsorViewTable = new MySponsorViewTableAdapter();
        SponsorshipTableAdapter sponsorshipTableAdapter = new SponsorshipTableAdapter();

        string saveEmail = SaveThings.email;
        string ID_User = "";
        string ID_Racer = "";
        string ID_Charity = "";
        string logoPath = "";

        string strSum;
        decimal sum;

        public MySponsors()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            racerTableAdapter.Fill(dataSet.Racer);
            userTableAdapter.Fill(dataSet.User);
            registrationTableAdapter.Fill(dataSet.Registration);
            charityTableAdapter.Fill(dataSet.Charity);
            sponsorshipTableAdapter.Fill(dataSet.Sponsorship);

            for (int j = 0; j < dataSet.Tables["User"].Rows.Count; j++)
            {
                if (saveEmail == dataSet.Tables["User"].Rows[j]["Email"].ToString())
                    ID_User = dataSet.Tables["User"].Rows[j]["ID_User"].ToString();
            }

            for (int j = 0; j < dataSet.Tables["Racer"].Rows.Count; j++)
            {
                if (ID_User == dataSet.Tables["Racer"].Rows[j]["ID_User"].ToString())
                    ID_Racer = dataSet.Tables["Racer"].Rows[j]["ID_Racer"].ToString();
            }

            for (int j = 0; j < dataSet.Tables["Registration"].Rows.Count; j++)
            {
                if (ID_Racer == dataSet.Tables["Registration"].Rows[j]["ID_Racer"].ToString())
                    ID_Charity = dataSet.Tables["Registration"].Rows[j]["ID_Charity"].ToString();
            }
            for (int j = 0; j < dataSet.Tables["Charity"].Rows.Count; j++)
            {
                if (ID_Charity == dataSet.Tables["Charity"].Rows[j]["ID_Сharity"].ToString())
                {
                    tbCharityName.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Name"].ToString();
                    tbCharityDescription.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Description"].ToString();
                    logoPath = dataSet.Tables["Charity"].Rows[j]["Charity_Logo"].ToString();

                    imgCharityLogo.Source = new BitmapImage(new Uri("C:\\Users\\sitka\\source\\repos\\Session\\SessionOne\\SessionOne\\Images\\Charity\\" + logoPath));
                }
            }
            for (int j = 0; j < dataSet.Tables["Sponsorship"].Rows.Count; j++)
            {
                if (ID_Racer == dataSet.Tables["Sponsorship"].Rows[j]["ID_Racer"].ToString())
                {
                    strSum = dataSet.Tables["Sponsorship"].Rows[j]["Amount"].ToString();
                    sum += decimal.Parse(strSum);
                }
            }

            mySponsorViewTable.FillBy(dataSet.MySponsorView, int.Parse(ID_Racer));
            listview.ItemsSource = dataSet.MySponsorView.DefaultView;
            tbAmount.Text = "Всего  $" + sum;
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
    }
}
