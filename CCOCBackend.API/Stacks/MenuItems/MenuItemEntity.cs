using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.MenuItems;
[Table("MenuItems")]
public class MenuItemEntity : Entity
{
    public string Name { get; set; }

    public string Link { get; set; }

    public MenuItemType Type { get; set; }

    public MenuItemEntity Parent { get; set; }

    public override string ToString()
    {
        return Id;
    }
}