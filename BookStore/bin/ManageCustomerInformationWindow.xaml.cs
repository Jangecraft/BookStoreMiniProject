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
    /// Interaction logic for ManageCustomerInformationWindow.xaml
    /// </summary>
    public partial class ManageCustomerInformationWindow : Window
    {
        string Name;
        public ManageCustomerInformationWindow(MainMenuWindow mainMenuWindow, string name)
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
            int numID;
            if (int.TryParse(txtID.Text, out numID))
            {
                List<List<string>> CustomersData = DataAccess.GetDataCustomers(numID);

                if (txtID.Text != "" &&
                    txtCName.Text != "" &&
                    txtAddress.Text != "" &&
                    txtEmail.Text != "")
                {
                    if (CustomersData.Count != 0)
                    {
                        MessageBox.Show("มีข้อมูลดังกล่าวแล้ว", "คำเตือน");
                    }
                    else
                    {
                        DataAccess.AddDataCustomers(numID,
                                            txtCName.Text,
                                            txtAddress.Text,
                                            txtEmail.Text);
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
                MessageBox.Show("กรุณากรอกรหัสสมาชิกเป็นตัวเลข", "คำเตือน");
            }
            
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int numID;
            if (int.TryParse(txtID.Text, out numID))
            {
                if (txtID.Text != "" &&
                txtCName.Text != "" &&
                txtAddress.Text != "" &&
                txtEmail.Text != "")
                {
                    DataAccess.UpdateDataCustomers(numID,
                                            txtCName.Text,
                                            txtAddress.Text,
                                            txtEmail.Text);
                    MessageBox.Show("แก้ไขข้อมูลเสร็จสิ้น");
                }
                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "คำเตือน");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสมาชิกเป็นตัวเลข", "คำเตือน");
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                int numID;
                if (int.TryParse(txtID.Text, out numID))
                {
                    DataAccess.DeleteDataCustomers(numID);
                    MessageBox.Show("ลบข้อมูลเสร็จสิ้น");
                }
                else
                {
                    MessageBox.Show("กรุณากรอกรหัสสมาชิกเป็นตัวเลข", "คำเตือน");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสมาชิก", "คำเตือน");
            }
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            txtID.Text = txtSearchID.Text;
            txtCName.Text = txtShowName.Text;
            txtAddress.Text = txtShowAddress.Text;
            txtEmail.Text = txtShowEmail.Text;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            int numID;
            if (int.TryParse(txtSearchID.Text, out numID))
            {
                List<List<string>> CustomersData = DataAccess.GetDataCustomers(numID);

                if (CustomersData.Count == 0)
                {
                    txtShowName.Text = "";
                    txtShowAddress.Text = "";
                    txtShowEmail.Text = "";
                    MessageBox.Show("ไม่พบข้อมูล", "คำเตือน");
                }
                else
                {
                    txtShowName.Text = CustomersData[0][1];
                    txtShowAddress.Text = CustomersData[0][2];
                    txtShowEmail.Text = CustomersData[0][3];
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสมาชิกเป็นตัวเลข", "คำเตือน");
            }
        }
    }
}
