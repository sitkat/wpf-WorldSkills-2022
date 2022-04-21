using System;
using System.Windows;
using System.Windows.Threading;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class ViewSponsors : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        RegistrationTableAdapter registrationTableAdapter = new RegistrationTableAdapter();
        SponsorshipTableAdapter sponsorshipTableAdapter = new SponsorshipTableAdapter();
        ViewSponsorsTableAdapter viewSponsorsTableAdapter = new ViewSponsorsTableAdapter();

        decimal sum;
        public ViewSponsors()
        {
            InitializeComponent();
            cbFilter.Items.Add("Наименование");
            cbFilter.Items.Add("Сумма");
            cbFilter.SelectedIndex = 0;

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            charityTableAdapter.Fill(dataSet.Charity);
            racerTableAdapter.Fill(dataSet.Racer);
            registrationTableAdapter.Fill(dataSet.Registration);
            sponsorshipTableAdapter.Fill(dataSet.Sponsorship);

            tbCharityCount.Text = dataSet.Tables["Charity"].Rows.Count.ToString();

            viewSponsorsTableAdapter.FillBy(dataSet.ViewSponsors);
            listview.ItemsSource = dataSet.ViewSponsors.DefaultView;

            for (int j = 0; j < dataSet.Tables["Sponsorship"].Rows.Count; j++)
            {
                sum += decimal.Parse(dataSet.Tables["Sponsorship"].Rows[j]["Amount"].ToString());
            }

            tbAmountCount.Text = "$" + sum.ToString();
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

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                viewSponsorsTableAdapter.FillByCharityName(dataSet.ViewSponsors);
                listview.ItemsSource = dataSet.ViewSponsors.DefaultView;
            }
            else if (cbFilter.SelectedIndex == 1)
            {
                viewSponsorsTableAdapter.FillByAmount(dataSet.ViewSponsors);
                listview.ItemsSource = dataSet.ViewSponsors.DefaultView;
            }
        }
    }
}
