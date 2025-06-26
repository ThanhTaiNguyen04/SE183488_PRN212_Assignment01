using System;
using System.Windows;
using BusinessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateCustomerDialog.xaml
    /// </summary>
    public partial class UpdateCustomerDialog : Window
    {
        private CustomerService cs = CustomerService.Instance;
        private InputValidator iv = new InputValidator();
        public UpdateCustomerDialog(Customer existingCustomer)
        {
            InitializeComponent();

            txtCustomerID.Text = existingCustomer.CustomerID.ToString();
            txtCompany.Text = existingCustomer.CompanyName;
            txtContactName.Text = existingCustomer.ContactName;
            txtContactTitle.Text = existingCustomer.ContactTitle;
            txtAddress.Text = existingCustomer.Address;
            txtPhone.Text = existingCustomer.Phone;

            txtCustomerID.IsReadOnly = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!iv.isPhoneValidation(txtPhone.Text))
            {
                MessageBox.Show("Thong tin khong hop le");
                return;
            }
            try
            {
                Customer customer = new Customer
                {
                    CustomerID = int.Parse(txtCustomerID.Text),
                    CompanyName = txtCompany.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = txtContactTitle.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };

                if (cs.UpdateCustomer(customer))
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
