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
using Services;
using BusinessLayer;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OrderProcessing.xaml
    /// </summary>
    public partial class OrderProcessing : Window
    {
        private OrderService os = OrderService.Instance;
        public OrderProcessing()
        {
            InitializeComponent();
            DisplayOrders();
        }

        private void DisplayOrders ()
        {
            lvOrder.ItemsSource = null;
            os.GenerateSampleDataset();
            lvOrder.ItemsSource = os.GetOrders();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderDialog addOrderDialog = new OrderDialog();
            if (addOrderDialog.ShowDialog() == true)
            {
                DisplayOrders();
            }

        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem is Order selectedOrder)
            {
                OrderUpdateDialog orderDialog = new OrderUpdateDialog(selectedOrder);
                if(orderDialog.ShowDialog() == true)
                {
                    MessageBox.Show("Cập nhật đơn hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    DisplayOrders();
                }
            }

        }

        private void btnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem is not Order order)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trong danh sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult mbr = MessageBox.Show("Bạn có muốn xóa đơn hàng này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            bool isSuccess = os.RemoveOrder(order.OrderID);

            if (isSuccess)
            {
                MessageBox.Show("Xóa đơn hàng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                DisplayOrders();
            }
            else
            {
                MessageBox.Show("Không thể xóa đơn hàng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearchOrder_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtSearchOrderID.Text);

            Order order = os.SearchOrder(id);

            if (order != null)
            {
                lvOrder.ItemsSource = null;
                lvOrder.ItemsSource = new List<Order> { order };
            }
            else
            {
                MessageBox.Show($"Không tìm thấy đơn hàng với mã {id}.", "Không tìm thấy", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
