// Models/Entities/Stock.cs
namespace InventorySystem.Models.Entities;
public class Stock
{
    public int StockID { get; set; }
    public int ProductID { get; set; }
    public Product Product { get; set; }

    public int SupplierID { get; set; }
    public Supplier Supplier { get; set; }

    public int QuantityAdded { get; set; }
    public DateTime DateAdded { get; set; }
}
