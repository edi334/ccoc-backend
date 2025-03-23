using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Pages;
public class PageFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }
    public string Slug { get; set; }
}