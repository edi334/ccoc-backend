using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Projects;
[Authorize(Roles = "Admin")]
[Display(Name = "Projects")]
public class ProjectsUiController : GenericModalAdminUiController<ProjectEntity, ProjectFormModel, ProjectViewModel, ProjectsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.TitleImage));
        Repo.ChainQueryable(q => q.Include(c => c.PresentationImage));
    }
}