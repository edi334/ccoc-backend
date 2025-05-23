using CCOCBackend.API.Pages;
using CCOCBackend.API.Stacks.PartnerTypes;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Partners;
public class PartnerFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    [DisablePatchSubProperties]
    public FileViewModel Image { get; set; }
    
    [FormlySelect(typeof(PartnerTypesAdminApiController), labelProp: "name", ShowReloadButton = true)]
    [DisablePatchSubProperties]
    public PartnerTypeViewModel Type { get; set; }
    
    public string Link { get; set; }
}