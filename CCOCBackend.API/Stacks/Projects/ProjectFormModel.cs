using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Projects;
public class ProjectFormModel : IFormModel
{
    public bool Enabled { get; set; }
    
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
    
    public bool IsParent { get; set; }
    
    public string ExternalUrl { get; set; }
    
    [DisablePatchSubProperties]
    [FormlySelect(typeof(ProjectsAdminApiController), labelProp: "title", ShowReloadButton = true)]
    public ProjectViewModel Parent { get; set; }
}