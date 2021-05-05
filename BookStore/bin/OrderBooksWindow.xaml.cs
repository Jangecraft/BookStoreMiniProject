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
    /// Interaction logic for PurchaseHistoryWindow.xaml
    /// </summary>
    public partial class OrderBooksWindow : Window
    {
        int numISBN,numID;
        int NumberProducts = 0;
        string Name;
        public OrderBooksWindow(MainMenuWindow mainMenuWindow, string name)
        {
            InitializeComponent();
            Name = name;
            txtName.Text = Name;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow(this, Name);
            mainMenuWindow.Show();
            this.Close();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtSearchIDBooks.Text, out numISBN))
            {
                List<List<string>> BooksData = DataAccess.GetDataBooks(numISBN);

                if (BooksData.Count == 0)
                {
                    txtShowName.Text = "";
                    txtShowDescription.Text = "";
                    txtShowPrice.Text = "";
                    MessageBox.Show("ไม่พบข้อมูล", "คำเตือน");
                }
                else
                {
                    txtShowName.Text = BooksData[0][1];
                    txtShowDescription.Text = BooksData[0][2];
                    txtShowPrice.Text = BooksData[0][3];
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสหนังสือเป็นตัวเลข", "คำเตือน");
            }
        }

        private void Increase_Button_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (int.TryParse(txtAmount.Text, out num))
            {
                NumberProducts = num;
            }

            if (NumberProducts >= 0)
            {
                NumberProducts += 1;
                txtAmount.Text = NumberProducts.ToString();
            }
            else
            {
                NumberProducts = 0;
                txtAmount.Text = NumberProducts.ToString();
            }
        }

        private void Decrease_Button_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (int.TryParse(txtAmount.Text, out num))
            {
                NumberProducts = num;
            }

            if (NumberProducts >= 1)
            {
                NumberProducts -= 1;
                txtAmount.Text = NumberProducts.ToString();
            }
            else
            {
                NumberProducts = 0;
                txtAmount.Text = NumberProducts.ToString();
            }
        }

        private void Okay_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIDCustomer.Text, out numID))
            {
                if (txtSearchIDBooks.Text == "")
                {
                    MessageBox.Show("กรุณากรอกรหัสหนังสือ", "คำเตือน");
                }
                else if (NumberProducts == 0)
                {
                    MessageBox.Show("ไม่สามารถซื้อหนังสือจำนวนศูนย์เล่มได้", "คำเตือน");
                }
                else if (txtShowName.Text == "" ||
                         txtShowDescription.Text == "" ||
                         txtShowPrice.Text == "")
                {
                    MessageBox.Show("ยังไม่ได้เลือกหนังสือ", "คำเตือน");
                }
                else if (txtIDCustomer.Text == "")
                {
                    MessageBox.Show("กรุณากรอกรหัสสมาชิก", "คำเตือน");
                }
                else
                {
                    DataAccess.AddDataTransactions(numISBN, numID, NumberProducts, int.Parse(txtShowPrice.Text), Name);
                    MessageBox.Show("สั่งซื้อเสร็จสิ้น");
                    txtShowNumIDBooks.Text = numISBN.ToString();
                    txtShowNumIDCustomer.Text = numID.ToString();
                    txtShowNumAmount.Text = NumberProducts.ToString();
                    txtShowNumPrice.Text = txtShowPrice.Text;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสมาชิกเป็นตัวเลข", "คำเตือน");
            }
        }
    }
}
