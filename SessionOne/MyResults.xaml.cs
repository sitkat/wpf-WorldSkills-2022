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
using SessionOne.DataSet1TableAdapters;

namespace SessionOne.Images
{
    public partial class MyResults : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();

        RaceTableAdapter raceTableAdapter = new RaceTableAdapter();
        EventTableAdapter eventTableAdapter = new EventTableAdapter();
        ResultTableAdapter resultTableAdapter = new ResultTableAdapter();
        Event_TypeTableAdapter event_TypeTableAdapter = new Event_TypeTableAdapter();

        MyResultsViewTableAdapter myResultsViewTableAdapter = new MyResultsViewTableAdapter();


        string saveEmail = SaveThings.email;
        string ID_User = "";
        string ID_Racer = "";
        string ID_Registration = "";
        string strGender = "";
        string strYears = "";
        string _dateOfBirth;
        public MyResults()
        {
            try
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

                eventTableAdapter.Fill(dataSet.Event);
                resultTableAdapter.Fill(dataSet.Result);
                raceTableAdapter.Fill(dataSet.Race);
                event_TypeTableAdapter.Fill(dataSet.Event_Type);

                for (int j = 0; j < dataSet.Tables["User"].Rows.Count; j++)
                {
                    if (saveEmail == dataSet.Tables["User"].Rows[j]["Email"].ToString())
                        ID_User = dataSet.Tables["User"].Rows[j]["ID_User"].ToString();
                }
                for (int j = 0; j < dataSet.Tables["Racer"].Rows.Count; j++)
                {
                    if (ID_User == dataSet.Tables["Racer"].Rows[j]["ID_User"].ToString())
                    {
                        ID_Racer = dataSet.Tables["Racer"].Rows[j]["ID_Racer"].ToString();
                        strGender = dataSet.Tables["Racer"].Rows[j]["Gender"].ToString();
                        _dateOfBirth = dataSet.Tables["Racer"].Rows[j]["DateOfBirth"].ToString();
                    }
                }
                for (int j = 0; j < dataSet.Tables["Registration"].Rows.Count; j++)
                {
                    if (ID_Racer == dataSet.Tables["Registration"].Rows[j]["ID_Racer"].ToString())
                        ID_Registration = dataSet.Tables["Registration"].Rows[j]["ID_Registration"].ToString();
                }

                myResultsViewTableAdapter.FillBy(dataSet.MyResultsView, int.Parse(ID_Registration));
                listview.ItemsSource = dataSet.MyResultsView.DefaultView;


                if (strGender == "F")
                    tbGender.Text = "Женщина";
                else
                    tbGender.Text = "Мужчина";
                DateTime dateOfBirth = Convert.ToDateTime(_dateOfBirth);
                DateTime dateNow = DateTime.Now;
                TimeSpan dateCheck = dateNow - dateOfBirth;
                DateTime age = DateTime.MinValue + dateCheck;
                int years = age.Year - 1;
                if (years <= 17)
                    tbYears.Text = "до 18";
                else if (years > 17 && years <= 29)
                    tbYears.Text = "от 18 до 29";
                else if (years > 29 && years <= 39)
                    tbYears.Text = "от 30 до 39";
                else if (years > 39 && years <= 55)
                    tbYears.Text = "от 40 до 55";
                else if (years > 55 && years <= 70)
                    tbYears.Text = "от 56 до 70";
                else
                    tbYears.Text = "более 70";
            }
            catch (Exception ex) { Console.WriteLine(ex); }

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

        private void btnBackToRacerMenu_Click_1(object sender, RoutedEventArgs e)
        {
            RacerMenu racerMenu = new RacerMenu();
            racerMenu.Show();
            Hide();
        }
    }
}
