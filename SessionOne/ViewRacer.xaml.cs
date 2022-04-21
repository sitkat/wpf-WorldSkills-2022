using SessionOne.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class ViewRacer : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();
        Registration_StatusTableAdapter registration_StatusTableAdapter = new Registration_StatusTableAdapter();
        Event_TypeTableAdapter event_TypeTableAdapter = new Event_TypeTableAdapter();
        ViewRacersTableAdapter viewRacersTableAdapter = new ViewRacersTableAdapter();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        CountryTableAdapter countryTableAdapter = new CountryTableAdapter();

        string ID_User = "";
        string ID_Racer = "";
        string ID_Charity = "";
        string photo = "";
        string strGender = "";
        string strCountry = "";
        string ID_Registration_Status = "";
        public ViewRacer()
        {
            InitializeComponent();

            userTableAdapter.Fill(dataSet.User);
            racerTableAdapter.Fill(dataSet.Racer);
            registrationTableAdapter.Fill(dataSet.Registration);
            registration_StatusTableAdapter.Fill(dataSet.Registration_Status);
            event_TypeTableAdapter.Fill(dataSet.Event_Type);
            viewRacersTableAdapter.Fill(dataSet.ViewRacers);
            charityTableAdapter.Fill(dataSet.Charity);
            countryTableAdapter.Fill(dataSet.Country);

            for (int j = 0; j < dataSet.Tables["User"].Rows.Count; j++)
            {
                if (SaveThings.EditEmail == dataSet.Tables["User"].Rows[j]["Email"].ToString())
                {
                    ID_User = dataSet.Tables["User"].Rows[j]["ID_User"].ToString();
                    tbEmail.Text = dataSet.Tables["User"].Rows[j]["Email"].ToString();
                    tbFirstName.Text = dataSet.Tables["User"].Rows[j]["First_Name"].ToString();
                    tbLastName.Text = dataSet.Tables["User"].Rows[j]["Last_Name"].ToString();
                }
            }
            for (int j = 0; j < dataSet.Tables["Racer"].Rows.Count; j++)
            {
                if (ID_User == dataSet.Tables["Racer"].Rows[j]["ID_User"].ToString())
                {
                    ID_Racer = dataSet.Tables["Racer"].Rows[j]["ID_Racer"].ToString();
                    strGender = dataSet.Tables["Racer"].Rows[j]["Gender"].ToString();
                    photo = dataSet.Tables["Racer"].Rows[j]["Photo"].ToString();
                    strCountry = dataSet.Tables["Racer"].Rows[j]["ID_Country"].ToString();
                    tbDateOfBirth.Text = dataSet.Tables["Racer"].Rows[j]["DateOfBirth"].ToString();
                    imgPhoto.Source = new BitmapImage(new Uri("C:\\Users\\sitka\\source\\repos\\Session\\SessionOne\\SessionOne\\Images\\" + photo));
                }
            }
            for (int j = 0; j < dataSet.Tables["Country"].Rows.Count; j++)
            {
                if (strCountry == dataSet.Tables["Country"].Rows[j]["ID_Country"].ToString())
                    tbCountry.Text = dataSet.Tables["Country"].Rows[j]["Country_Name"].ToString();
            }
            for (int j = 0; j < dataSet.Tables["Registration"].Rows.Count; j++)
            {
                if (ID_Racer == dataSet.Tables["Registration"].Rows[j]["ID_Racer"].ToString())
                {
                    ID_Charity = dataSet.Tables["Registration"].Rows[j]["ID_Charity"].ToString();
                    tbEvent.Text = dataSet.Tables["Registration"].Rows[j]["ID_Event_Type"].ToString();
                    ID_Registration_Status = dataSet.Tables["Registration"].Rows[j]["ID_Registration_Status"].ToString();
                    tbAmount.Text = "$" + dataSet.Tables["Registration"].Rows[j]["SponsorshipTarget"].ToString();
                }
            }
            for (int j = 0; j < dataSet.Tables["Charity"].Rows.Count; j++)
            {
                if (ID_Charity == dataSet.Tables["Charity"].Rows[j]["ID_Сharity"].ToString())
                    tbCharity.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Name"].ToString();
            }
            for (int j = 0; j < dataSet.Tables["Registration_Status"].Rows.Count; j++)
            {
                if (ID_Registration_Status == dataSet.Tables["Registration_Status"].Rows[j]["ID_Registration_Status"].ToString())
                    tbStatus.Text = dataSet.Tables["Registration_Status"].Rows[j]["Statu_Name"].ToString();
            }
            if (strGender == "F")
                tbGender.Text = "Female";
            else
                tbGender.Text = "Male";


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
        private void btnUpdateRacerByCoordinator_Click(object sender, RoutedEventArgs e)
        {
            UpdateRacerByCoordinator updateRacerByCoordinator = new UpdateRacerByCoordinator();
            updateRacerByCoordinator.Show();
            Hide();
        }
        private void btnBackViewRacers_Click(object sender, RoutedEventArgs e)
        {
            ViewRacers viewRacers = new ViewRacers();
            viewRacers.Show();
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
