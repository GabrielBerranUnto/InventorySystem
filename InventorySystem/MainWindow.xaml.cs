using System.Windows;
using InventorySystem.Views;

namespace InventorySystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ProductsPage()); // Default page
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SuppliersPage());
        }

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StockPage());
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SalesPage());
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }
}
