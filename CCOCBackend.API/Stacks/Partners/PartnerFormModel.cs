using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Partners;
public class PartnerFormModel : IFormModel
{
    public string Name { get; set; }
    public PartnerType PartnerType { get; set; }

    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    [DisablePatchSubProperties]
    public FileViewModel Image { get; set; }
    
    public string Link { get; set; }
}