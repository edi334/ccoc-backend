using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Resources;
public class ResourceFormModel : IFormModel
{
    public string Title { get; set; }
    
    [FormlyCkEditor]
    public string Description { get; set; }

    public int Year { get; set; }

    public ResourceType Type { get; set; }
    
    public string Subtype { get; set; }
    
    public string Authors { get; set; }

    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel File { get; set; }
}