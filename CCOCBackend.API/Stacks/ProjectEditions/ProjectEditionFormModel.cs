using CCOCBackend.API.Stacks.Projects;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.ProjectEditions;
public class ProjectEditionFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }

    [FormlySelect(typeof(ProjectsAdminApiController), labelProp: "name", ShowReloadButton = true)]
    public ProjectViewModel Project { get; set; }
}