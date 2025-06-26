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
                int cid = int.Parse(txtCustomerID.Text);
                int eid = int.Parse(txtEmployeeID.Text);
                int oid = int.Parse(txtOrderID.Text);

                if(iv.IsCustomerIDExist(cid) || !iv.IsEmployeeIDExist(eid) || !iv.IsOrderIDExist(oid))
                {
                    return;
                }

                Order order = new Order
                {
                    OrderID = int.Parse(txtOrderID.Text),
                    CustomerID = int.Parse(txtCustomerID.Text),
                    EmployeeID = int.Parse(txtEmployeeID.Text),
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
                };
                
                if(os.UpdateOrder(order))
                {
                    DialogResult = true;
                    Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
