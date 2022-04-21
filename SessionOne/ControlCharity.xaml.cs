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
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class ControlCharity : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();
        public ControlCharity()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            charityTableAdapter.Fill(dataSet.Charity);
            listview.ItemsSource = dataSet.Charity.DefaultView;
            listview.SelectedValuePath = "Charity_Name";
        }
        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void btnBackToAdminMenu_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
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
            SaveThings.NameCharity = listview.SelectedValue.ToString();
            AddCharity addCharity = new AddCharity();
            addCharity.Show();
            Hide();
        }

        private void addCharity_Click(object sender, RoutedEventArgs e)
        {
            SaveThings.NameCharity = "";
            AddCharity addCharity = new AddCharity();
            addCharity.Show();
            Hide();
        }
    }
}
