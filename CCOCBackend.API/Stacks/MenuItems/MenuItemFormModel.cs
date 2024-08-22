using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.MenuItems;
public class MenuItemFormModel : IFormModel
{
    public string Name { get; set; }

    public string Link { get; set; }

    public MenuItemType Type { get; set; }

    [FormlySelect(typeof(MenuItemsAdminApiController), labelProp: "name", ShowReloadButton = true)]
    public MenuItemViewModel Parent { get; set; }
}