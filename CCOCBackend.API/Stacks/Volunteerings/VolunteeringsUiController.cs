using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Volunteerings;

[Authorize(Roles = "Admin")]
[Display(Name = "Volunteerings")]
public class VolunteeringsUiController : GenericModalAdminUiController<VolunteeringEntity, VolunteeringFormModel, VolunteeringViewModel, VolunteeringsAdminApiController>
{
}