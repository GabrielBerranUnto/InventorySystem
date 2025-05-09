﻿// Models/Entities/Sale.cs
namespace InventorySystem.Models.Entities;
public class Sale
{
    public int SaleID { get; set; }
    public int ProductID { get; set; }
    public Product Product { get; set; }

    public int QuantitySold { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
}
