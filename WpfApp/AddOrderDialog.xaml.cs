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
            int cid = int.Parse(txtCustomerID.Text);
            int eid = int.Parse(txtEmployeeID.Text);
            int oid = int.Parse(txtOrderID.Text);

            if (iv.IsCustomerIDExist(cid) || !iv.IsEmployeeIDExist(eid) || !iv.IsOrderIDExist(oid))
            {
                return null;
            }

            return new Order
            {
                OrderID = int.Parse(txtOrderID.Text),
                CustomerID = int.Parse(txtCustomerID.Text),
                EmployeeID = int.Parse(txtEmployeeID.Text),
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
                    MessageBox.Show("Thong tin nhap khong hop le");
                    return;
                }
                bool isSuccess = os.AddOrder(order);
                if (isSuccess)
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Khong the them don hang vui long kiem tra thong tin");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
