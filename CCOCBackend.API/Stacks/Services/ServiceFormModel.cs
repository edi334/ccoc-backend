using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Services;
public class ServiceFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyCkEditor]
    public string Description { get; set; }
    
    public string FormLink { get; set; }
    
    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel Image { get; set; }
}