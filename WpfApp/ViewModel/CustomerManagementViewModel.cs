using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BusinessLayer;
using Services;

namespace WpfApp.ViewModel
{
    public class CustomerManagementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public string SearchCustomerId { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CustomerManagementViewModel()
        {
            Customers = new ObservableCollection<Customer>(CustomerService.Instance.GetCustomers());
            AddCommand = new RelayCommand(_ => AddCustomer());
            UpdateCommand = new RelayCommand(_ => UpdateCustomer(), _ => SelectedCustomer != null);
            RemoveCommand = new RelayCommand(_ => RemoveCustomer(), _ => SelectedCustomer != null);
            SearchCommand = new RelayCommand(_ => SearchCustomer());
        }

        private void AddCustomer()
        {
            var dialog = new AddCustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                Customers.Clear();
                foreach (var c in CustomerService.Instance.GetCustomers())
                    Customers.Add(c);
            }
        }
        private void UpdateCustomer()
        {
            if (SelectedCustomer == null) return;
            var dialog = new UpdateCustomerDialog(SelectedCustomer);
            if (dialog.ShowDialog() == true)
            {
                Customers.Clear();
                foreach (var c in CustomerService.Instance.GetCustomers())
                    Customers.Add(c);
                System.Windows.MessageBox.Show("Bạn đã cập nhật thành công");
            }
        }
        private void RemoveCustomer()
        {
            if (SelectedCustomer == null) return;
            var result = System.Windows.MessageBox.Show($"Bạn có muốn xóa khách hàng '{SelectedCustomer.CompanyName}' không?", "Xác nhận xóa", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
            if (result == System.Windows.MessageBoxResult.Yes)
            {
                CustomerService.Instance.RemoveCustomer(SelectedCustomer.CustomerID);
                Customers.Remove(SelectedCustomer);
            }
        }
        private void SearchCustomer()
        {
            if (int.TryParse(SearchCustomerId, out int id))
            {
                var found = CustomerService.Instance.SearchCustomer(id);
                Customers.Clear();
                if (found != null) Customers.Add(found);
            }
        }
    }
} 