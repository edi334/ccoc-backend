using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Pages;
[Authorize(Roles = "Admin")]
public class PagesAdminApiController : CrudAdminApiController<PageEntity, PageFormModel, PageViewModel>
{
}