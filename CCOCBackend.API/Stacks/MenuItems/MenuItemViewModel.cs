using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.MenuItems;
[Display(Name = "MenuItem")]
public class MenuItemViewModel : ViewModel
{
    public string Name { get; set; }

    public string Link { get; set; }

    public MenuItemType Type { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public MenuItemViewModel Parent { get; set; }

    public override string ToString()
    {
        return Id;
    }
}