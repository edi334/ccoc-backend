using MCMS.Base.Data.FormModels;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.CarouselPages;
public class CarouselPageFormModel : IFormModel
{
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel Image { get; set; }

    public string Name { get; set; }

    public bool Enabled { get; set; }
}