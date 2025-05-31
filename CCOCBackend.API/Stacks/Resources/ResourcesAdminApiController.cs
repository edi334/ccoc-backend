using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Resources;
[Authorize(Roles = "Admin")]
public class ResourcesAdminApiController : CrudAdminApiController<ResourceEntity, ResourceFormModel, ResourceViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.File));
    }
    
    protected override Task OnCreating(ResourceEntity e)
    {
        if (e.File != null)
            e.File = ServiceProvider.GetRepo<FileEntity>().Attach(e.File);

        return Task.CompletedTask;
    }
}