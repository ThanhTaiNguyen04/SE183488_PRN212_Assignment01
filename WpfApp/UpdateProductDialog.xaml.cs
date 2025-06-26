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
            if (!int.TryParse(txtProductID.Text, out int productId) ||
                !int.TryParse(txtSupplierID.Text, out int supplierId) ||
                !int.TryParse(txtCategoryID.Text, out int categoryId) ||
                !int.TryParse(txtQuantityPerUnit.Text, out int quantityPerUnit) ||
                !double.TryParse(txtUnitPrice.Text, out double unitPrice) ||
                !int.TryParse(txtUnitsInStock.Text, out int unitsInStock) ||
                !int.TryParse(txtUnitsOnOrder.Text, out int unitsOnOrder) ||
                !int.TryParse(txtReorderLevel.Text, out int reorderLevel))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho các trường thông tin sản phẩm!", "Lỗi định dạng", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!iv.IsCategoryIDExist(categoryId))
            {
                MessageBox.Show("Mã loại sản phẩm không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                Product product = new Product
                {
                    ProductID = productId,
                    ProductName = txtProductName.Text,
                    SupplierID = supplierId,
                    CategoryID = categoryId,
                    QuantityPerUnit = quantityPerUnit,
                    UnitPrice = unitPrice,
                    UnitsInStock = unitsInStock,
                    UnitsOnOrder = unitsOnOrder,
                    ReorderLevel = reorderLevel,
                    Discontinued = chkDiscontinued.IsChecked ?? false
                };

                if (ps.UpdateProduct(product))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật sản phẩm. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
