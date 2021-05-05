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
    /// Interaction logic for OrderBooksWindow.xaml
    /// </summary>
    public partial class PurchaseHistoryWindow : Window
    {
        string Name;
        public List<HistoryOrder> Orders { get; set; }
        public PurchaseHistoryWindow(MainMenuWindow mainMenuWindow, string name)
        {
            InitializeComponent();
            Name = name;

            AddHistoryOrder();

            DataContext = this;
        }

        private void AddHistoryOrder()
        {
            List<List<string>> getOrders = DataAccess.GetHistoryOrderData();

            Orders = new List<HistoryOrder>();

            int i = 0;
            foreach (List<string> data in getOrders) 
            {
                HistoryOrder historyOrder = new HistoryOrder();
                historyOrder.ISBN = getOrders[i][1].ToString();
                historyOrder.Customers_ID = getOrders[i][2].ToString();
                historyOrder.Quatity = getOrders[i][3].ToString();
                historyOrder.Total_Price = getOrders[i][4].ToString();
                historyOrder.Personnel_Name = getOrders[i][5].ToString();

                Orders.Add(historyOrder);
                i++;
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow(this, Name);
            mainMenuWindow.Show();
            this.Close();
        }
    }
}
