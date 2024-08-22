using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Tags;
[Authorize(Roles = "Admin")]
public class TagsAdminApiController : CrudAdminApiController<TagEntity, TagFormModel, TagViewModel>
{
}