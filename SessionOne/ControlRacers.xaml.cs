using SessionOne.DataSet1TableAdapters;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Threading;

namespace SessionOne
{
    public partial class ControlRacers : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        Helper helper = new Helper();

        DataSet1 dataSet = new DataSet1();
        UserTableAdapter userTableAdapter = new UserTableAdapter();

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Karting; Integrated Security = True";
        string sqlExpression = "";
        public ControlRacers()
        {
            InitializeComponent();
            TimeToEvent.Text = helper.CountTimeToEvent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            cbFilter.Items.Add("Имя");
            cbFilter.Items.Add("Фамилия");
            cbFilter.Items.Add("Email");
            cbFilter.SelectedIndex = 0;

            cbRole.Items.Add("All");
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Racer");
            cbRole.Items.Add("Coordinator");
            cbRole.SelectedIndex = 0;

            userTableAdapter.Fill(dataSet.User);

            listview.ItemsSource = dataSet.User.DefaultView;
            listview.SelectedValuePath = "Email";
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string orderBy = "";
            string roleName = "";
            if (cbFilter.SelectedIndex == 0)
                orderBy = "First_Name";
            else if (cbFilter.SelectedIndex == 1)
                orderBy = "Last_Name";
            else
                orderBy = "Email";

            if (cbRole.SelectedIndex == 0)
                roleName = "";
            else if (cbRole.SelectedIndex == 1)
                roleName = "A";            
            else if (cbRole.SelectedIndex == 2)
                roleName = "R";
            else
                roleName = "C";
            sqlExpression = $"select * from [dbo].[User] where concat([First_Name],[Last_Name],[Email]) like '%{tbSearch.Text}%' and [ID_Role] like '%{roleName}%' order by [{orderBy}]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlExpression, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listview.ItemsSource = dt.DefaultView;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SaveThings.EditEmail = listview.SelectedValue.ToString();
            UpdateUserByAdmin updateUserByAdmin = new UpdateUserByAdmin();
            updateUserByAdmin.Show();
            Hide();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            Hide();
        }
    }
}
