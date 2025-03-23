using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.Volunteerings;

public class VolunteeringFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Text { get; set; }
    public string LinkTo { get; set; }
}