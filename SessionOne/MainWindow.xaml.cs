using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        public MainWindow()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void HelmetImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FirstTimeRacer firstTimeRacer = new FirstTimeRacer();
            firstTimeRacer.Show();
            Hide();
        }

        private void MoneyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sponsor sponsor = new Sponsor();
            sponsor.Show();
            Hide();
        }

        private void KeyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Hide();
        }

        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void DetailedInformationImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DetailedInformation detailedInformation = new DetailedInformation();
            detailedInformation.Show();
            Hide();
        }
    }
}
