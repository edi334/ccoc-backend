using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.ProjectEditions;
[Authorize(Roles = "Admin")]
[Display(Name = "ProjectEditions")]
public class ProjectEditionsUiController : GenericModalAdminUiController<ProjectEditionEntity, ProjectEditionFormModel, ProjectEditionViewModel, ProjectEditionsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Project));
    }
}