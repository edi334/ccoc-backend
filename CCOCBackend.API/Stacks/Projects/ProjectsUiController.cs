using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Projects;
[Authorize(Roles = "Admin")]
[Display(Name = "Projects")]
public class ProjectsUiController : GenericModalAdminUiController<ProjectEntity, ProjectFormModel, ProjectViewModel, ProjectsAdminApiController>
{
}