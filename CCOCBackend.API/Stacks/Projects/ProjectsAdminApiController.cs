using CCOCBackend.API.Stacks.Articles;
using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Projects;
[Authorize(Roles = "Admin")]
public class ProjectsAdminApiController : CrudAdminApiController<ProjectEntity, ProjectFormModel, ProjectViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.TitleImage));
        Repo.ChainQueryable(q => q.Include(c => c.PresentationImage));
    }
    
    protected override Task OnCreating(ProjectEntity e)
    {
        if (e.TitleImage != null)
            e.TitleImage = ServiceProvider.GetRepo<FileEntity>().Attach(e.TitleImage);
        if (e.PresentationImage != null)
            e.PresentationImage = ServiceProvider.GetRepo<FileEntity>().Attach(e.PresentationImage);

        return Task.CompletedTask;
    }
}