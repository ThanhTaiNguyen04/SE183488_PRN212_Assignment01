using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BusinessLayer;
using Services;

namespace WpfApp.ViewModel
{
    public class ProductManagementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set { _selectedProduct = value; OnPropertyChanged(); }
        }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public string SearchProductId { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ProductManagementViewModel()
        {
            CategoryService.Instance.GenerateSampleDataset();
            ProductService.Instance.GenerateSampleDataset();
            Products = new ObservableCollection<Product>(ProductService.Instance.GetProducts());
            AddCommand = new RelayCommand(_ => AddProduct());
            UpdateCommand = new RelayCommand(_ => UpdateProduct(), _ => SelectedProduct != null);
            RemoveCommand = new RelayCommand(_ => RemoveProduct(), _ => SelectedProduct != null);
            SearchCommand = new RelayCommand(_ => SearchProduct());
        }

        private void AddProduct()
        {
            var dialog = new AddProductDialog();
            if (dialog.ShowDialog() == true)
            {
                Products.Clear();
                foreach (var p in ProductService.Instance.GetProducts())
                    Products.Add(p);
            }
        }
        private void UpdateProduct()
        {
            if (SelectedProduct == null) return;
            var dialog = new UpdateProductDialog(SelectedProduct);
            if (dialog.ShowDialog() == true)
            {
                Products.Clear();
                foreach (var p in ProductService.Instance.GetProducts())
                    Products.Add(p);
                System.Windows.MessageBox.Show("Bạn đã cập nhật thành công");
            }
        }
        private void RemoveProduct()
        {
            if (SelectedProduct == null) return;
            var result = System.Windows.MessageBox.Show($"Bạn có muốn xóa sản phẩm '{SelectedProduct.ProductName}' không?", "Xác nhận xóa", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
            if (result == System.Windows.MessageBoxResult.Yes)
            {
                ProductService.Instance.RemoveProduct(SelectedProduct.ProductID);
                Products.Remove(SelectedProduct);
            }
        }
        private void SearchProduct()
        {
            if (int.TryParse(SearchProductId, out int id))
            {
                var found = ProductService.Instance.SearchProduct(id);
                Products.Clear();
                if (found != null) Products.Add(found);
            }
        }
    }
} 