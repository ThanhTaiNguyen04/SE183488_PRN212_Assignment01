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
    /// Interaction logic for AddCustomerDialog.xaml
    /// </summary>
    public partial class AddCustomerDialog : Window
    {
        private CustomerService cs = CustomerService.Instance;
        private InputValidator iv = new InputValidator();
        public AddCustomerDialog()
        {
            InitializeComponent();
        }

        private Customer CreateCustomerFromForm()
        {
            return new Customer
            {
                CustomerID = int.Parse(txtCustomerID.Text),
                CompanyName = txtCompany.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
            };
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerID == null || txtContactTitle == null
                || txtContactName == null || txtCompany == null ||
                txtAddress == null || txtPhone == null)
            {
                MessageBox.Show("Hay nhap du lieu de them"); return;
            }

            if (!iv.isPhoneValidation(txtPhone.Text))
            {
                MessageBox.Show("Sai format so dien thoai, hay nhap nhu vi du sau:\n+84901234567\r\n\r\n84901234567\r\n\r\n0901234567");
                return;
            }

            try
            {
                Customer customer = CreateCustomerFromForm();

                bool isSuccess = cs.AddCustomer(customer);

                if (isSuccess) {
                    DialogResult = true;
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Khong the them khach hang vui long kiem tra thong tin");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
