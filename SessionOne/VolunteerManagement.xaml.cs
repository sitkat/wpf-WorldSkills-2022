using System;
using System.Windows;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class VolunteerManagement : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        VolunteerTableAdapter volunteerTableAdapter = new VolunteerTableAdapter();
        Volunteer_ViewTableAdapter volunteer_ViewTableAdapter = new Volunteer_ViewTableAdapter();

        public VolunteerManagement()
        {
            InitializeComponent();
            cbFilter.Items.Add("Фамилия");
            cbFilter.Items.Add("Имя");
            cbFilter.Items.Add("Страна");
            cbFilter.Items.Add("Пол");
            cbFilter.SelectedIndex = 0;

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();


            volunteerTableAdapter.Fill(dataSet.Volunteer);
            volunteer_ViewTableAdapter.Fill(dataSet.Volunteer_View);
            listview.ItemsSource = dataSet.Volunteer_View.DefaultView;
            tbCount.Text = dataSet.Tables["Volunteer"].Rows.Count.ToString();

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

        private void btnBackToAdminMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            Hide();
        }


        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                volunteer_ViewTableAdapter.FillByLastName(dataSet.Volunteer_View);
                listview.ItemsSource = dataSet.Volunteer_View.DefaultView;
            }
            else if (cbFilter.SelectedIndex == 1)
            {
                volunteer_ViewTableAdapter.FillByFirstName(dataSet.Volunteer_View);
                listview.ItemsSource = dataSet.Volunteer_View.DefaultView;
            }
            else if (cbFilter.SelectedIndex == 2)
            {
                volunteer_ViewTableAdapter.FillByCountry(dataSet.Volunteer_View);
                listview.ItemsSource = dataSet.Volunteer_View.DefaultView;
            }
            else
            {
                volunteer_ViewTableAdapter.FillByGender(dataSet.Volunteer_View);
                listview.ItemsSource = dataSet.Volunteer_View.DefaultView;
            }
        }
    }
}
