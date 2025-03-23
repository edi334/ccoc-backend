using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Volunteerings;

[Authorize(Roles = "Admin")]
public class VolunteeringsAdminApiController : CrudAdminApiController<VolunteeringEntity, VolunteeringFormModel, VolunteeringViewModel>
{
}