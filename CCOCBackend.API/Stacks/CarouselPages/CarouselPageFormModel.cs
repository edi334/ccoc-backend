using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.CarouselPages;
public class CarouselPageFormModel : IFormModel
{
    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel Image { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public bool Enabled { get; set; }
}