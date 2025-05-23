using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Projects;
public class ProjectFormModel : IFormModel
{
    public string Title { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }
    
    public ProjectType Type { get; set; }
    
    public string Slug { get; set; }
    
    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel TitleImage { get; set; }
    
    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel PresentationImage { get; set; }
}