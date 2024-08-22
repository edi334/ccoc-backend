using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.Projects;
public class ProjectFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }
}