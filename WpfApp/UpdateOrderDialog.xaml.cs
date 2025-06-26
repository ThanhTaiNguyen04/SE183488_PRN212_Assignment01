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
    /// Interaction logic for OrderUpdateDialog.xaml
    /// </summary>
    public partial class OrderUpdateDialog : Window
    {
        OrderService os = OrderService.Instance;
        InputValidator iv = new InputValidator();
        public OrderUpdateDialog(Order existingOrder)
        {
            InitializeComponent();

            txtOrderID.Text = existingOrder.OrderID.ToString();
            txtCustomerID.Text = existingOrder.CustomerID.ToString();
            txtEmployeeID.Text = existingOrder.EmployeeID.ToString();
            dpOrderDate.SelectedDate = existingOrder.OrderDate;

            txtOrderID.IsReadOnly = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCustomerID.Text, out int cid) ||
                    !int.TryParse(txtEmployeeID.Text, out int eid) ||
                    !int.TryParse(txtOrderID.Text, out int oid))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số cho các trường mã!", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!iv.IsEmployeeIDExist(eid) || !iv.IsOrderIDExist(oid))
                {
                    MessageBox.Show("Mã nhân viên hoặc mã đơn hàng không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Order order = new Order
                {
                    OrderID = oid,
                    CustomerID = cid,
                    EmployeeID = eid,
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
                };
                
                if(os.UpdateOrder(order))
                {
                    MessageBox.Show("Cập nhật đơn hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật đơn hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
