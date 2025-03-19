using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Reports;
public class ReportFormModel : IFormModel
{
    [FormlyCkEditor]
    public string Description { get; set; }

    public int Year { get; set; }

    public ReportType Type { get; set; }

    [DisablePatchSubProperties]
    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel File { get; set; }
}