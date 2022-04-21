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
    public partial class DetailedInformation : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        public DetailedInformation()
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

        private void KartSkills_Click(object sender, RoutedEventArgs e)
        {
            KartInformation kartInformation = new KartInformation();
            kartInformation.Show();
            Hide();
        }

        private void PastResults_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CharityList_Click(object sender, RoutedEventArgs e)
        {
            Charity charity = new Charity();
            charity.Show();
            Hide();
        }
    }
}
