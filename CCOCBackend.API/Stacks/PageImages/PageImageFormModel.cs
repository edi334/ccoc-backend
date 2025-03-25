using CCOCBackend.API.Pages;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.PageImages;
public class PageImageFormModel : IFormModel
{
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    [DisablePatchSubProperties]
    public FileViewModel Image { get; set; }

    [FormlySelect(typeof(PagesAdminApiController), labelProp: "name", ShowReloadButton = true)]
    [DisablePatchSubProperties]
    public PageViewModel Page { get; set; }
}