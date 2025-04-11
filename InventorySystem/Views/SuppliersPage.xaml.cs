using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InventorySystem.Data;
using InventorySystem.Models.Entities;

namespace InventorySystem.Views
{
    public partial class SuppliersPage : UserControl
    {
        private readonly ApplicationDbContext _context;

        public SuppliersPage()
        {
            InitializeComponent();
            _context = new ApplicationDbContextFactory().CreateDbContext();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            SupplierGrid.ItemsSource = _context.Suppliers.ToList();
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            var supplier = new Supplier
            {
                Name = SupplierNameBox.Text,
                ContactInfo = ContactBox.Text
            };

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            LoadSuppliers();
            Clear();
        }

        private void UpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierGrid.SelectedItem is Supplier selected)
            {
                selected.Name = SupplierNameBox.Text;
                selected.ContactInfo = ContactBox.Text;

                _context.Suppliers.Update(selected);
                _context.SaveChanges();
                LoadSuppliers();
                Clear();
            }
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierGrid.SelectedItem is Supplier selected)
            {
                _context.Suppliers.Remove(selected);
                _context.SaveChanges();
                LoadSuppliers();
                Clear();
            }
        }

        private void SupplierGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupplierGrid.SelectedItem is Supplier selected)
            {
                SupplierNameBox.Text = selected.Name;
                ContactBox.Text = selected.ContactInfo;
            }
        }

        private void Clear()
        {
            SupplierNameBox.Clear();
            ContactBox.Clear();
            SupplierGrid.UnselectAll();
        }
    }
}
