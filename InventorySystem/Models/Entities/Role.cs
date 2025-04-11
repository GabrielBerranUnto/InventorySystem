// Models/Entities/Role.cs
using InventorySystem.Models.Entities;
namespace InventorySystem.Models.Entities;
public class Role
{
    public int RoleID { get; set; }
    public string RoleName { get; set; }

    public ICollection<User> Users { get; set; }
}
