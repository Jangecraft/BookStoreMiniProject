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
    /// Interaction logic for ManageBookInformationWindow.xaml
    /// </summary>
    public partial class ManageBookInformationWindow : Window
    {
        string Name;
        public ManageBookInformationWindow(MainMenuWindow mainMenuWindow, string name)
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

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            int numID, numPrice;
            if (int.TryParse(txtID.Text, out numID) && 
                int.TryParse(txtPrice.Text, out numPrice))
            {
                List<List<string>> BooksData = DataAccess.GetDataBooks(numID);

                if (txtID.Text != "" &&
                    txtBName.Text != "" &&
                    txtDescription.Text != "" &&
                    txtPrice.Text != "")
                {
                    if (BooksData.Count != 0)
                    {
                        MessageBox.Show("มีข้อมูลดังกล่าวแล้ว", "คำเตือน");
                    }
                    else
                    {
                        DataAccess.AddDataBooks(numID,
                                            txtBName.Text,
                                            txtDescription.Text,
                                            numPrice);
                        MessageBox.Show("เพิ่มข้อมูลเสร็จสิ้น");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "คำเตือน");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสหนังสือเป็นตัวเลข", "คำเตือน");
            }
        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int numID, numPrice;
            if (int.TryParse(txtID.Text, out numID) &&
                int.TryParse(txtPrice.Text, out numPrice))
            {
                if (txtID.Text != "" &&
                txtBName.Text != "" &&
                txtDescription.Text != "" &&
                txtPrice.Text != "")
                {
                    DataAccess.UpdateDataBooks(numID,
                                            txtBName.Text,
                                            txtDescription.Text,
                                            numPrice);
                    MessageBox.Show("แก้ไขข้อมูลเสร็จสิ้น");
                }
                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "คำเตือน");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสหนังสือเป็นตัวเลข", "คำเตือน");
            }
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                int numID;
                if (int.TryParse(txtID.Text, out numID))
                {
                    DataAccess.DeleteDataBooks(numID);
                    MessageBox.Show("ลบข้อมูลเสร็จสิ้น");
                }
                else
                {
                    MessageBox.Show("กรุณากรอกรหัสหนังสือเป็นตัวเลข", "คำเตือน");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสหนังสือ", "คำเตือน");
            }
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = txtSearchID.Text;
            txtBName.Text = txtShowName.Text;
            txtDescription.Text = txtShowDescription.Text;
            txtPrice.Text = txtShowPrice.Text;
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            int numID;
            if (int.TryParse(txtSearchID.Text, out numID))
            {
                List<List<string>> BooksData = DataAccess.GetDataBooks(numID);

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
    }
}
