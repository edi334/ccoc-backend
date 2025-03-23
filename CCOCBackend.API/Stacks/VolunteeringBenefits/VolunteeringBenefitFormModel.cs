using CCOCBackend.API.Stacks.Volunteerings;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.Api.Stacks.VolunteeringBenefits;
public class VolunteeringBenefitFormModel : IFormModel
{
    public string Name { get; set; }

    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    [DisablePatchSubProperties]
    public FileViewModel Image { get; set; }

    [FormlySelect(typeof(VolunteeringsAdminApiController), labelProp: "name", ShowReloadButton = true)]
    [DisablePatchSubProperties]
    public VolunteeringViewModel Volunteering { get; set; }
}