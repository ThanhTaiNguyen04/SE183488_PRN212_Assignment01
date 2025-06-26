using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagement cm = new CustomerManagement();
            cm.Show();
            Close();
        }

        private void btnProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductManagement pm = new ProductManagement();
            pm.Show();
            Close();
        }
        private void btnOrderProcessing_Click(object sender, RoutedEventArgs e)
        {
            OrderProcessing op = new OrderProcessing();
            op.Show();
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Welcome welcome = new Welcome();
                welcome.Show();
                this.Close();
            }
        }
    }
}