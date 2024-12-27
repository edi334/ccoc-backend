using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PTags;
[Authorize(Roles = "Admin")]
public class PTagsAdminApiController : CrudAdminApiController<PTagEntity, PTagFormModel, PTagViewModel>;