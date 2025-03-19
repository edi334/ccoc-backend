using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Shortcuts;
public class ShortcutFormModel : IFormModel
{
    public string Name { get; set; }

    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel Image { get; set; }

    public bool Enabled { get; set; }

    public string Link { get; set; }
}