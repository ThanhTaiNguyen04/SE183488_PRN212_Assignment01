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
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text) || string.IsNullOrWhiteSpace(txtContactTitle.Text)
                || string.IsNullOrWhiteSpace(txtContactName.Text) || string.IsNullOrWhiteSpace(txtCompany.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thêm khách hàng.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning); return;
            }

            if (!iv.isPhoneValidation(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập theo định dạng: 0901234567, 84901234567 hoặc +84901234567.", "Sai định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Customer customer = CreateCustomerFromForm();

                bool isSuccess = cs.AddCustomer(customer);

                if (isSuccess) {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                } else {
                    MessageBox.Show("Không thể thêm khách hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm khách hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
