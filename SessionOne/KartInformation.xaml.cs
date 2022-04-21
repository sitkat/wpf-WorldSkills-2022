using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class KartInformation : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        public KartInformation()
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

        private void imgKart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FullMap fullMap = new FullMap();
            fullMap.Show();
            Hide();
        }

        private void btnBackDetailInformation_Click(object sender, RoutedEventArgs e)
        {
            DetailedInformation detailedInformation = new DetailedInformation();
            detailedInformation.Show();
            Hide();
        }
    }
}
