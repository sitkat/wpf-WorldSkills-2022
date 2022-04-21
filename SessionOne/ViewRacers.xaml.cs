using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class ViewRacers : Window
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

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Karting; Integrated Security = True";
        string sqlExpression = "";
        public ViewRacers()
        {
            InitializeComponent();

            cbFilter.Items.Add("Имя");
            cbFilter.Items.Add("Фамилия");
            cbFilter.Items.Add("Email");
            cbFilter.SelectedIndex = 0;

            cbEventType.Items.Add("2.5km Race");
            cbEventType.Items.Add("4km Race");
            cbEventType.Items.Add("6.5km Race");
            cbEventType.SelectedIndex = 0;

            cbStatus.Items.Add("Registered");
            cbStatus.Items.Add("Payment Confirmed");
            cbStatus.Items.Add("Race Attended");
            cbStatus.SelectedIndex = 0;

            userTableAdapter.Fill(dataSet.User);
            racerTableAdapter.Fill(dataSet.Racer);
            registrationTableAdapter.Fill(dataSet.Registration);
            registration_StatusTableAdapter.Fill(dataSet.Registration_Status);
            event_TypeTableAdapter.Fill(dataSet.Event_Type);
            viewRacersTableAdapter.Fill(dataSet.ViewRacers);

            listview.ItemsSource = dataSet.ViewRacers.DefaultView;
            listview.SelectedValuePath = "Email";

            tbRacerCount.Text = dataSet.Tables["Racer"].Rows.Count.ToString();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string orderBy = "";
            if (cbFilter.SelectedIndex == 0)
                orderBy = "First_Name";
            else if (cbFilter.SelectedIndex == 1)
                orderBy = "Last_Name";
            else
                orderBy = "Email";
            sqlExpression = $"select * from [dbo].[ViewRacers] where Statu_Name = '{cbStatus.Text}' AND [Event_Type_Name] = '{cbEventType.Text}'  order by [{orderBy}]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlExpression, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listview.ItemsSource = dt.DefaultView;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void btnBackToCoordinatorMenu_Click(object sender, RoutedEventArgs e)
        {
            CoordinatorMenu coordinatorMenu = new CoordinatorMenu();
            coordinatorMenu.Show();
            Hide();
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SaveThings.EditEmail = listview.SelectedValue.ToString();
            ViewRacer viewRacer = new ViewRacer();
            viewRacer.Show();
            Hide();
        }
    }
}
