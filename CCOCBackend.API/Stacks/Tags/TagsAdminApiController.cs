using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Tags;
[Authorize(Roles = "Admin")]
public class TagsAdminApiController : CrudAdminApiController<TagEntity, TagFormModel, TagViewModel>;