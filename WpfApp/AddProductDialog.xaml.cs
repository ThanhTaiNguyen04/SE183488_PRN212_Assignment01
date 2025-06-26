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
    /// Interaction logic for AddProductDialog.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        private ProductService ps = ProductService.Instance;
        private InputValidator iv = new InputValidator();
        public AddProductDialog()
        {
            InitializeComponent();
        }

        private Product CreateProductFromForm()
        {
            return new Product
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text,
                SupplierID = int.Parse(txtSupplierID.Text),
                CategoryID = int.Parse(txtCategoryID.Text),
                QuantityPerUnit = int.Parse(txtQuantityPerUnit.Text),
                UnitPrice = double.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitsInStock.Text),
                UnitsOnOrder = int.Parse(txtUnitsOnOrder.Text),
                ReorderLevel = int.Parse(txtReorderLevel.Text),
                Discontinued = chkDiscontinued.IsChecked ?? false
            };
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int pid = int.Parse(txtProductID.Text);
            int sid = int.Parse(txtSupplierID.Text);
            int cid = int.Parse(txtCategoryID.Text);

            if (iv.IsProductIDExist(pid) || !iv.IsCategoryIDExist(cid))
            {
                MessageBox.Show("Thong tin khong hop le hoac san pham da ton tai");
                return;
            }

            try
            {
                Product product = CreateProductFromForm();

                bool isSuccess = ps.AddProduct(product);

                if (isSuccess)
                {
                    DialogResult = true;
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Khong the them san pham vui long kiem tra thong tin");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
