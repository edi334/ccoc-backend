using CCOCBackend.API.Stacks.Partners;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.PartnerTypes;
public class PartnerTypeFormModel : IFormModel
{
    public string Name { get; set; }
}