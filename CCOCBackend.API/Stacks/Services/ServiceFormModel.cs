using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.Services;
public class ServiceFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }
}