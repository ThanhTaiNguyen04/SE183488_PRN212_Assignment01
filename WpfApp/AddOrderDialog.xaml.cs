using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for OrderDialog.xaml
    /// </summary>
    public partial class OrderDialog : Window
    {
        private OrderService os = OrderService.Instance;
        private InputValidator iv = new InputValidator();
        public OrderDialog()
        {
            InitializeComponent();
        }

        private Order CreateOrderFromForm()
        {
            if (!int.TryParse(txtCustomerID.Text, out int cid) ||
                !int.TryParse(txtEmployeeID.Text, out int eid) ||
                !int.TryParse(txtOrderID.Text, out int oid))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho các trường mã!", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            if (iv.IsCustomerIDExist(cid) || !iv.IsEmployeeIDExist(eid) || !iv.IsOrderIDExist(oid))
            {
                return null;
            }

            return new Order
            {
                OrderID = oid,
                CustomerID = cid,
                EmployeeID = eid,
                OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
            };
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = CreateOrderFromForm();
                if (order == null)
                {
                    MessageBox.Show("Thông tin nhập không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                bool isSuccess = os.AddOrder(order);
                if (isSuccess)
                {
                    MessageBox.Show("Thêm đơn hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm đơn hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm đơn hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
