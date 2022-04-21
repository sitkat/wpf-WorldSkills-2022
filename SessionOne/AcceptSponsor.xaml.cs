using System;
using System.Windows;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class AcceptSponsor : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        string str = "$ ";
        public AcceptSponsor()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            CharityTB.Text = SaveThings.charName;
            PaymentTB.Text = SaveThings.payment;
            RacerTB.Text = SaveThings.racerName;

            PaymentTB.Text = str + PaymentTB.Text;
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
    }
}
