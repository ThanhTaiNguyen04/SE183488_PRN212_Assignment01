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
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        EmployeeService employeeService = EmployeeService.Instance;
        List<Employee> employees = new List<Employee>();
        public EmployeeLogin()
        {
            InitializeComponent();
            employeeService.GenerateSampleDataset();
            employees = employeeService.GetEmployees();
        }

        private void btnEmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            Employee emp = employees.FirstOrDefault(e => e.UserName.Equals(username) && e.Password.Equals(password));

            if (emp != null) {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            } else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}
