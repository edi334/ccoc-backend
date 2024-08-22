using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.People;
[Authorize(Roles = "Admin")]
public class PeopleAdminApiController : CrudAdminApiController<PersonEntity, PersonFormModel, PersonViewModel>
{
}