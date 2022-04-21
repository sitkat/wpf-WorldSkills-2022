using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class UpdateRacer : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        GenderTableAdapter genderTableAdapter = new GenderTableAdapter();
        CountryTableAdapter countryTableAdapter = new CountryTableAdapter();
        RacerTableAdapter racerTableAdapter = new RacerTableAdapter();
        UserTableAdapter userTableAdapter = new UserTableAdapter();

        string ID_User = "";
        string ID_Racer = "";
        string saveEmail = SaveThings.email;

        OpenFileDialog dialog = new OpenFileDialog();


        public UpdateRacer()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            genderTableAdapter.Fill(dataSet.Gender);
            countryTableAdapter.Fill(dataSet.Country);
            racerTableAdapter.Fill(dataSet.Racer);
            userTableAdapter.Fill(dataSet.User);

            cbGender.ItemsSource = dataSet.Gender.DefaultView;
            cbGender.DisplayMemberPath = "Gender_Name";
            cbGender.SelectedValuePath = "ID_Gender";
            cbGender.SelectedIndex = 0;

            cbCountry.ItemsSource = dataSet.Country.DefaultView;
            cbCountry.DisplayMemberPath = "Country_Name";
            cbCountry.SelectedValuePath = "ID_Country";
            cbCountry.SelectedIndex = 0;

            for (int j = 0; j < dataSet.Tables["User"].Rows.Count; j++)
            {
                if (saveEmail == dataSet.Tables["User"].Rows[j]["Email"].ToString())
                {
                    ID_User = dataSet.Tables["User"].Rows[j]["ID_User"].ToString();
                    tbEmail.Text = dataSet.Tables["User"].Rows[j]["Email"].ToString();
                    tbPassword.Password = dataSet.Tables["User"].Rows[j]["Password"].ToString();
                    tbRepeatPassword.Password = dataSet.Tables["User"].Rows[j]["Password"].ToString();
                    tbName.Text = dataSet.Tables["User"].Rows[j]["First_Name"].ToString();
                    tbLastName.Text = dataSet.Tables["User"].Rows[j]["Last_Name"].ToString();
                }
            }
            for (int j = 0; j < dataSet.Tables["Racer"].Rows.Count; j++)
            {
                if (ID_User == dataSet.Tables["Racer"].Rows[j]["ID_User"].ToString())
                {
                    ID_Racer = dataSet.Tables["Racer"].Rows[j]["ID_Racer"].ToString();
                    cbGender.SelectedValue = dataSet.Tables["Racer"].Rows[j]["Gender"].ToString();
                    tbPhoto.Text = dataSet.Tables["Racer"].Rows[j]["Photo"].ToString();
                    tbDateOfBirth.Text = dataSet.Tables["Racer"].Rows[j]["DateOfBirth"].ToString();
                    cbCountry.SelectedValue = dataSet.Tables["Racer"].Rows[j]["ID_Country"].ToString();
                    imgPhoto.Source = new BitmapImage(new Uri("C:\\Users\\sitka\\source\\repos\\Session\\SessionOne\\SessionOne\\Images\\" + tbPhoto.Text));
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateOfBirth = Convert.ToDateTime(tbDateOfBirth.Text);
                DateTime dateNow = DateTime.Now;
                TimeSpan dateCheck = dateNow - dateOfBirth;
                DateTime age = DateTime.MinValue + dateCheck;
                int Years = age.Year - 1;
                if (Years < 10 || Years > 100)
                    MessageBox.Show("Вы не проходите по возрасту");
                Regex passwordValidation = new Regex(@"^(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]){6,}");
                if (string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbPassword.Password.ToString()) || string.IsNullOrEmpty(tbRepeatPassword.Password.ToString()) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastName.Text) || string.IsNullOrEmpty(tbDateOfBirth.Text))
                    MessageBox.Show("Заполните все поля!");
                else if (!passwordValidation.IsMatch(tbPassword.Password.ToString()))
                    MessageBox.Show("Пароль не соответствует требованиям: \nМинимум 6 символов\nМинимум 1 прописная буква\nМинимум 1 цифра\nМинимум 1 спецсимвол");
                else if (tbPassword.Password.ToString() != tbRepeatPassword.Password.ToString())
                    MessageBox.Show("Пароли не совпадают!");
                else
                {
                    racerTableAdapter.UpdateQuery(tbName.Text, tbLastName.Text, cbGender.SelectedValue.ToString(), dateOfBirth.ToString(), cbCountry.SelectedValue.ToString(), int.Parse(ID_User), tbPhoto.Text, int.Parse(ID_Racer));
                    userTableAdapter.UpdateQuery(int.Parse(ID_User), tbEmail.Text, tbPassword.Password.ToString(), tbName.Text, tbLastName.Text, "R");

                    RacerMenu racerMenu = new RacerMenu();
                    racerMenu.Show();
                    Hide();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        private void tbDateOfBirth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbDateOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbDateOfBirth.Text.Length == 4 || tbDateOfBirth.Text.Length == 7)
            {
                tbDateOfBirth.Text = tbDateOfBirth.Text + "-";
                tbDateOfBirth.SelectionStart = tbDateOfBirth.Text.Length;
            }
        }

        private void btnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            dialog.InitialDirectory = @"C:\Users\sitka\source\repos\Session\SessionOne\SessionOne\Images\";
            dialog.Title = "Выберите фото профиля";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                tbPhoto.Text = dialog.SafeFileName;
                imgPhoto.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            RacerMenu racerMenu = new RacerMenu();
            racerMenu.Show();
            Hide();
        }
        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }
    }
}
