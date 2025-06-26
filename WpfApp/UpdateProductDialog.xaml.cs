using System;
using System.Windows;
using BusinessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateProductDialog.xaml
    /// </summary>
    public partial class UpdateProductDialog : Window
    {
        private ProductService ps = ProductService.Instance;
        private InputValidator iv = new InputValidator();
        public UpdateProductDialog(Product existingProduct)
        {
            InitializeComponent();

            txtProductID.Text = existingProduct.ProductID.ToString();
            txtProductName.Text = existingProduct.ProductName;
            txtSupplierID.Text = existingProduct.SupplierID.ToString();
            txtCategoryID.Text = existingProduct.CategoryID.ToString();
            txtQuantityPerUnit.Text = existingProduct.QuantityPerUnit.ToString();
            txtUnitPrice.Text = existingProduct.UnitPrice.ToString();
            txtUnitsInStock.Text = existingProduct.UnitsInStock.ToString();
            txtUnitsOnOrder.Text = existingProduct.UnitsOnOrder.ToString();
            txtReorderLevel.Text = existingProduct.ReorderLevel.ToString();
            chkDiscontinued.IsChecked = existingProduct.Discontinued;

            txtProductID.IsReadOnly = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!iv.IsCategoryIDExist(int.Parse(txtCategoryID.Text)))
            {
                MessageBox.Show("ID khong ton tai");
                return;
            }
            try
            {
                Product product = new Product
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

                if (ps.UpdateProduct(product))
                {
                    DialogResult = true;
                    Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
