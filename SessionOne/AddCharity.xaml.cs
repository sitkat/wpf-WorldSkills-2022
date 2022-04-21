using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using SessionOne.DataSet1TableAdapters;

namespace SessionOne
{
    public partial class AddCharity : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        CharityTableAdapter charityTableAdapter = new CharityTableAdapter();

        OpenFileDialog dialog = new OpenFileDialog();

        string _NameCharity = SaveThings.NameCharity;
        string ID_Charity = "";
        public AddCharity()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            charityTableAdapter.Fill(dataSet.Charity);

            for (int j = 0; j < dataSet.Tables["Charity"].Rows.Count; j++)
            {
                if (_NameCharity == dataSet.Tables["Charity"].Rows[j]["Charity_Name"].ToString())
                {
                    ID_Charity = dataSet.Tables["Charity"].Rows[j]["ID_Сharity"].ToString();
                    tbName.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Name"].ToString();
                    tbDescription.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Description"].ToString();
                    tbPhoto.Text = dataSet.Tables["Charity"].Rows[j]["Charity_Logo"].ToString();
                    imgPhoto.Source = new BitmapImage(new Uri("C:\\Users\\sitka\\source\\repos\\Session\\SessionOne\\SessionOne\\Images\\Charity\\" + tbPhoto.Text));
                }
            }
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbDescription.Text))
                MessageBox.Show("Заполните все поля!");
            else if (string.IsNullOrEmpty(_NameCharity))
            {
                charityTableAdapter.Insert(tbName.Text, tbDescription.Text, tbPhoto.Text);
                ControlCharity controlCharity = new ControlCharity();
                controlCharity.Show();
                Hide();
            }
            else
            {
                charityTableAdapter.UpdateQuery(tbName.Text, tbDescription.Text, tbPhoto.Text, int.Parse(ID_Charity));
                ControlCharity controlCharity = new ControlCharity();
                controlCharity.Show();
                Hide();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ControlCharity controlCharity = new ControlCharity();
            controlCharity.Show();
            Hide();
        }

        private void btnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\Users\sitka\source\repos\Session\SessionOne\SessionOne\Images\Charity\";
            dialog.Title = "Выберите логотип организации";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                tbPhoto.Text = dialog.SafeFileName;
                imgPhoto.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
    }
}
