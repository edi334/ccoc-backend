using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PartnerTypes;
[Authorize(Roles = "Admin")]
[Display(Name = "PartnerTypes")]
public class PartnerTypesUiController : GenericModalAdminUiController<PartnerTypeEntity, PartnerTypeFormModel, PartnerTypeViewModel, PartnerTypesAdminApiController>
{
}