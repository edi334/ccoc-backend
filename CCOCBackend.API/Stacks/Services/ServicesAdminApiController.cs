using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Services;
[Authorize(Roles = "Admin")]
public class ServicesAdminApiController : CrudAdminApiController<ServiceEntity, ServiceFormModel, ServiceViewModel>
{
}