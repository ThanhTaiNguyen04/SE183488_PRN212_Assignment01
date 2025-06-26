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
                    DisplayOrders();
                }
            }

        }

        private void btnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {

            if (lvOrder.SelectedItem is not Order order)
            {
                MessageBox.Show("Please select an order on the list");
                return;
            }

            MessageBoxResult mbr = MessageBox.Show("Ban muon xoa don hang?", "Xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            bool isSuccess = os.RemoveOrder(order.OrderID);

            if (isSuccess)
            {
                DisplayOrders();
            }
            else
            {
                MessageBox.Show("Khong the xoa don hang");
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
                MessageBox.Show($"No Order with {id} found");
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
