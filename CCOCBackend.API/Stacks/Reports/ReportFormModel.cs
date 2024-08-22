using MCMS.Base.Data.FormModels;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Reports;
public class ReportFormModel : IFormModel
{
    public string Name { get; set; }

    public string Year { get; set; }

    public ReportType Type { get; set; }

    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel File { get; set; }
}