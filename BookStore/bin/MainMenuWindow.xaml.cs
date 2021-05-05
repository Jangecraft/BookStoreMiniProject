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
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        string Name;
        public MainMenuWindow(RegisterWindow registerWindow, string personnel_Name)
        {
            InitializeComponent();
            Name = personnel_Name;
            txtName.Text = Name;
        }
        public MainMenuWindow(LoginWindow loginWindow, string personnel_Name)
        {
            InitializeComponent();
            Name = personnel_Name;
            txtName.Text = Name;
        }
        public MainMenuWindow(ManageCustomerInformationWindow manageCustomerInformationWindow, string name)
        {
            InitializeComponent();
            Name = name;
            txtName.Text = Name;
        }
        public MainMenuWindow(ManageBookInformationWindow manageBookInformationWindow, string name)
        {
            InitializeComponent();
            Name = name;
            txtName.Text = Name;
        }
        public MainMenuWindow(OrderBooksWindow orderBooksWindow, string name)
        {
            InitializeComponent();
            Name = name;
            txtName.Text = Name;
        }
        public MainMenuWindow(PurchaseHistoryWindow purchaseHistoryWindow, string name)
        {
            InitializeComponent();
            Name = name;
            txtName.Text = Name;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.Show();
            this.Close();
        }

        private void Customer_Button_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomerInformationWindow manageCustomerInformationWindow = new ManageCustomerInformationWindow(this, Name);
            manageCustomerInformationWindow.Show();
            this.Close();
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            ManageBookInformationWindow manageBookInformationWindow = new ManageBookInformationWindow(this, Name);
            manageBookInformationWindow.Show();
            this.Close();
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            OrderBooksWindow orderBooksWindow = new OrderBooksWindow(this, Name);
            orderBooksWindow.Show();
            this.Close();
        }

        private void History_Button_Click(object sender, RoutedEventArgs e)
        {
            PurchaseHistoryWindow purchaseHistoryWindow = new PurchaseHistoryWindow(this, Name);
            purchaseHistoryWindow.Show();
            this.Close();
        }
    }
}
