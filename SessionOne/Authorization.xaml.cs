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
    public partial class Authorization : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        RoleTableAdapter roleTableAdapter = new RoleTableAdapter();
        UserTableAdapter userTableAdapter = new UserTableAdapter();
        public Authorization()
        {
            InitializeComponent();

            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            roleTableAdapter.Fill(dataSet.Role);
            userTableAdapter.Fill(dataSet.User);
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < dataSet.Tables["User"].Rows.Count; j ++)
            {
                if (EmailForm.Text.Contains(dataSet.Tables["User"].Rows[j]["Email"].ToString()) && PasswordForm.Password.Contains(dataSet.Tables["User"].Rows[j]["Password"].ToString()))
                {
                    string ID_Role = dataSet.Tables["User"].Rows[j]["ID_Role"].ToString();
                    SaveThings.email = EmailForm.Text;
                    switch (ID_Role)
                    {
                        case "A":
                            {
                                AdminMenu adminMenu = new AdminMenu();
                                adminMenu.Show();
                                Hide();
                                break;
                            }
                        case "C":
                            {
                                CoordinatorMenu coordinatorMenu = new CoordinatorMenu();
                                coordinatorMenu.Show();
                                Hide();
                                break;
                            }
                        case "R":
                            {
                                RacerMenu racerMenu = new RacerMenu();
                                racerMenu.Show();
                                Hide();
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                    txtError.Text = "Неверный email или пароль";
            }
        }
    }
}
