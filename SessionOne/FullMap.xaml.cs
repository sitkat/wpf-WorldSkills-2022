using System;
using System.Windows;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class FullMap : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        public FullMap()
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

        private void btnToKartInformation_Click(object sender, RoutedEventArgs e)
        {
            KartInformation kartInformation = new KartInformation();
            kartInformation.Show();
            Hide();
        }
    }
}
