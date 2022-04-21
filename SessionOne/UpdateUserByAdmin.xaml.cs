using SessionOne.DataSet1TableAdapters;
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

namespace SessionOne
{
    public partial class UpdateUserByAdmin : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        RoleTableAdapter roleTableAdapter = new RoleTableAdapter();
        string saveEmail = SaveThings.EditEmail;
        string ID_User = "";
        public UpdateUserByAdmin()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            userTableAdapter.Fill(dataSet.User);
            roleTableAdapter.Fill(dataSet.Role);

            cbRole.ItemsSource = dataSet.Role.DefaultView;
            cbRole.DisplayMemberPath = "Role_Name";
            cbRole.SelectedValuePath = "ID_Role";
            cbRole.SelectedIndex = 0;

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
                    cbRole.SelectedValue = dataSet.Tables["User"].Rows[j]["ID_Role"].ToString();
                }
            }
        }
        private void timerTick(object sender, EventArgs e)
        {
            TimeToEvent.Text = helper.CountTimeToEvent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Regex passwordValidation = new Regex(@"^(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*]){6,}");
            if (string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbPassword.Password.ToString()) || string.IsNullOrEmpty(tbRepeatPassword.Password.ToString()) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbLastName.Text))
                MessageBox.Show("Заполните все поля!");
            else if (!passwordValidation.IsMatch(tbPassword.Password.ToString()))
                MessageBox.Show("Пароль не соответствует требованиям: \nМинимум 6 символов\nМинимум 1 прописная буква\nМинимум 1 цифра\nМинимум 1 спецсимвол");
            else if (tbPassword.Password.ToString() != tbRepeatPassword.Password.ToString())
                MessageBox.Show("Пароли не совпадают!");
            else
            {
                userTableAdapter.UpdateQuery(int.Parse(ID_User), tbEmail.Text, tbPassword.Password.ToString(), tbName.Text, tbLastName.Text, cbRole.SelectedValue.ToString());

                ControlRacers controlRacers = new ControlRacers();
                controlRacers.Show();
                Hide();
            }
        }
        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ControlRacers controlRacers = new ControlRacers();
            controlRacers.Show();
            Hide();
        }
    }
}
