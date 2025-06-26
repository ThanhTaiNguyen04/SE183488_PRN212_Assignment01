using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Interaction logic for CustomerOrderWindow.xaml
    /// </summary>
    public partial class CustomerOrderWindow : Window
    {
        OrderService orderService = OrderService.Instance;
        OrderDetailService orderDetailService = OrderDetailService.Instance;
        List<Order> orders = new List<Order>();
        List<OrderDetail> orderDetails = new List<OrderDetail>();
        private Customer currentCustomer;
        public CustomerOrderWindow(Customer currentCustomer)
        {
            InitializeComponent();
            this.currentCustomer = currentCustomer;
            orderService.GenerateSampleDataset();
            orderDetailService.GenerateSampleDataset();
            DisplayOrders(currentCustomer);
        }

        private void DisplayOrders(Customer currentCustomer)
        {
            lvCustomerOrders.ItemsSource = null;
            orders = orderService.GetOrders().Where(o => o.CustomerID == currentCustomer.CustomerID).ToList();
            orderDetails = orderDetailService.GetOrderDetails();

            var displayList = (from order in orders
                               join detail in orderDetails
                               on order.OrderID equals detail.OrderID
                               select new
                               {
                                   OrderID = order.OrderID,
                                   CustomerID = order.CustomerID,
                                   EmployeeID = order.EmployeeID,
                                   OrderDate = order.OrderDate,
                                   ProductID = detail.ProductID,
                                   UnitPrice = detail.UnitPrice,
                                   Quantity = detail.Quantity,
                                   Discount = detail.Discount
                               }).ToList();

            lvCustomerOrders.ItemsSource = displayList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CustomerMainForm mainForm = new CustomerMainForm(currentCustomer);
            mainForm.Show();
            this.Close();
        }
    }
}
