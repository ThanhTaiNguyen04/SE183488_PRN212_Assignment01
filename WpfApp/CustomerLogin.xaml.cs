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
using BusinessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {
        CustomerService cs = CustomerService.Instance;
        InputValidator iv = new InputValidator();
        List<Customer> customers = new List<Customer>();    
        public CustomerLogin()
        {
            InitializeComponent();
            cs.GenerateSampleDataset();
            customers = cs.GetCustomers();
        }

        private void btnCustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = txtPhone.Text;
            if(!iv.isPhoneValidation(phone))
            {
                MessageBox.Show(
                    "Số điện thoại không hợp lệ. Vui lòng nhập đúng định dạng!\n\nVí dụ: 0901234567",
                    "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Customer c = customers.FirstOrDefault(cus => cus.Phone.Equals(phone));

            if (c != null) {
                CustomerMainForm cmf = new CustomerMainForm(c);
                cmf.Show();
                Close();
            }else
            {
                MessageBox.Show("Số điện thoại đăng nhập sai hoặc không tồn tại!", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}
