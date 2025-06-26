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
    /// Interaction logic for ProfileManagement.xaml
    /// </summary>
    public partial class ProfileManagement : Window
    {
        InputValidator iv = new InputValidator();
        CustomerService cs = CustomerService.Instance;
        private Customer currentCustomer;
        public ProfileManagement(Customer currentCustomer)
        {
            InitializeComponent();
            this.currentCustomer = currentCustomer;
            txtCustomerID.Text = currentCustomer.CustomerID.ToString();
            txtCompanyName.Text = currentCustomer.CompanyName.ToString();
            txtAddress.Text = currentCustomer.Address.ToString();
            txtContactTitle.Text = currentCustomer.ContactTitle.ToString();
            txtPhone.Text = currentCustomer.Phone.ToString();
            txtContactName.Text = currentCustomer.ContactName.ToString();

            txtCustomerID.IsReadOnly = true;
        }

        public ProfileManagement()
        {
            InitializeComponent();
        }

        private Customer CreateCustomerFromForm()
        {
            return new Customer
            {
                CustomerID = int.Parse(txtCustomerID.Text),
                CompanyName = txtCompanyName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
            };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!iv.isPhoneValidation(txtPhone.Text))
            {
                MessageBox.Show("So dien thoai khong hop le");
                return;
            }

            Customer customer = CreateCustomerFromForm();

            if (cs.UpdateCustomer(customer))
            {
                MessageBox.Show("Cap nhat thanh cong");
            }
            else
            {
                MessageBox.Show("Cap nhat that bai");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogin cl = new CustomerLogin();
            cl.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CustomerMainForm mainForm = new CustomerMainForm(currentCustomer);
            mainForm.Show();
            this.Close();
        }
    }
}
