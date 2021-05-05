using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        public LoginWindow(RegisterWindow registerWindow)
        {
            InitializeComponent();
        }

        public LoginWindow(MainMenuWindow mainMenuWindow)
        {
            InitializeComponent();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(this);
            registerWindow.Show();
            this.Close();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=ShopInformation.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ($"SELECT Personnel_Name from Personnel WHERE Personnel_User = '{txtUser.Text}' AND Personnel_Password = '{txtPassword.Text}'", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                int check = 0;
                string Personnel_Name;

                while (query.Read())
                {
                    Personnel_Name = query.GetString(0);

                    MainMenuWindow mainMenuWindow = new MainMenuWindow(this, Personnel_Name);
                    mainMenuWindow.Show();
                    this.Close();

                    check = 1;
                }

                if (check == 0)
                {
                    MessageBox.Show("ไม่พบข้อมูล", "คำเตือน");
                }

                db.Close();

            }
        }
    }
}
