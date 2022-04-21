using SessionOne.Images;
using System;
using System.Windows;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class RacerMenu : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();
        public RacerMenu()
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

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForARace registrationForARace = new RegistrationForARace();
            registrationForARace.Show();
            Hide();
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRacer updateRacer = new UpdateRacer();
            updateRacer.Show();
            Hide();
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            MyResults myResults = new MyResults();
            myResults.Show();
            Hide();
        }

        private void SponsorButton_Click(object sender, RoutedEventArgs e)
        {
            MySponsors mySponsors = new MySponsors();
            mySponsors.Show();
            Hide();
        }
    }
}
