// Models/Entities/Product.cs
using InventorySystem.Models.Entities;
namespace InventorySystem.Models.Entities;
public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }

    public ICollection<Stock> StockEntries { get; set; }
    public ICollection<Sale> Sales { get; set; }
    public ICollection<SupplierProduct> SupplierLinks { get; set; }
}
