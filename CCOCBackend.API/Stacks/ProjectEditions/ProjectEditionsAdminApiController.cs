using MCMS.Controllers.Api;
using System.Threading.Tasks;
using CCOCBackend.API.Stacks.Projects;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.ProjectEditions;
[Authorize(Roles = "Admin")]
public class ProjectEditionsAdminApiController : CrudAdminApiController<ProjectEditionEntity, ProjectEditionFormModel, ProjectEditionViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Project));
    }

    protected override Task OnCreating(ProjectEditionEntity e)
    {
        if (e.Project != null)
            e.Project = ServiceProvider.GetRepo<ProjectEntity>().Attach(e.Project);
        return Task.CompletedTask;
    }
}