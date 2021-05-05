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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.Show();
            this.Close();
        }

        private void Okay_Button_Click(object sender, RoutedEventArgs e)
        {
            List<List<string>> PersonnelData = DataAccess.GetDataPersonnel(txtUser.Text);

            if (txtName.Text == "" || txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบ", "คำเตือน");
            }
            else
            {
                if (PersonnelData.Count != 0)
                {
                    MessageBox.Show("มีUserดังกล่าวแล้ว", "คำเตือน");
                }
                else
                {
                    DataAccess.AddDataPersonnel(txtName.Text, txtUser.Text, txtPassword.Text);
                    MainMenuWindow mainMenuWindow = new MainMenuWindow(this, txtName.Text);
                    mainMenuWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
