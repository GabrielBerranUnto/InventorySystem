// Models/Entities/SupplierProduct.cs
namespace InventorySystem.Models.Entities;
public class SupplierProduct
{
    public int SupplierID { get; set; }
    public Supplier Supplier { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}
