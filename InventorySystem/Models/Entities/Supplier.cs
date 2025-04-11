// Models/Entities/Supplier.cs
using InventorySystem.Models.Entities;
namespace InventorySystem.Models.Entities;
public class Supplier
{
    public int SupplierID { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public ICollection<Stock> StockEntries { get; set; }
    public ICollection<SupplierProduct> ProductLinks { get; set; }
}
