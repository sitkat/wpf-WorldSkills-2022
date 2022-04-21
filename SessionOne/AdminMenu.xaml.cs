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
    public partial class AdminMenu : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        public AdminMenu()
        {
            InitializeComponent();

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

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            ControlRacers controlRacers = new ControlRacers();
            controlRacers.Show();
            Hide();
        }

        private void btnDonate_Click(object sender, RoutedEventArgs e)
        {
            ControlCharity controlCharity = new ControlCharity();
            controlCharity.Show();
            Hide();
        }

        private void btnCooldudes_Click(object sender, RoutedEventArgs e)
        {
            VolunteerManagement volunteerManagement = new VolunteerManagement();
            volunteerManagement.Show();
            Hide();
        }

        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
