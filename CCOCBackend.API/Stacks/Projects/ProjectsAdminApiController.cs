using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Projects;
[Authorize(Roles = "Admin")]
public class ProjectsAdminApiController : CrudAdminApiController<ProjectEntity, ProjectFormModel, ProjectViewModel>
{
}