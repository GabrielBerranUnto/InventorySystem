using System.Windows.Controls;
using System.Windows;
using InventorySystem.Data;
using InventorySystem.Models.Entities;
using System.Linq;

namespace InventorySystem.Views
{
    public partial class ProductsPage : UserControl
    {
        private readonly ApplicationDbContext _context;

        public ProductsPage()
        {
            InitializeComponent();
            _context = new ApplicationDbContextFactory().CreateDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductGrid.ItemsSource = _context.Products.ToList();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(PriceBox.Text, out decimal price))
            {
                var product = new Product
                {
                    Name = NameBox.Text,
                    Category = CategoryBox.Text,
                    Price = price
                };

                _context.Products.Add(product);
                _context.SaveChanges();
                LoadProducts();
                ClearFields();
            }
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selected && decimal.TryParse(PriceBox.Text, out decimal price))
            {
                selected.Name = NameBox.Text;
                selected.Category = CategoryBox.Text;
                selected.Price = price;

                _context.Products.Update(selected);
                _context.SaveChanges();
                LoadProducts();
                ClearFields();
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selected)
            {
                _context.Products.Remove(selected);
                _context.SaveChanges();
                LoadProducts();
                ClearFields();
            }
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selected)
            {
                NameBox.Text = selected.Name;
                CategoryBox.Text = selected.Category;
                PriceBox.Text = selected.Price.ToString("F2");
            }
        }

        private void ClearFields()
        {
            NameBox.Clear();
            CategoryBox.Clear();
            PriceBox.Clear();
            ProductGrid.UnselectAll();
        }
    }
}
