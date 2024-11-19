using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Tags;
[Authorize(Roles = "Admin")]
public class TagsAdminApiController : CrudAdminApiController<TagEntity, TagFormModel, TagViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Icon));
    }
    
    protected override Task OnCreating(TagEntity e)
    {
        if (e.Icon != null)
            e.Icon = ServiceProvider.GetRepo<FileEntity>().Attach(e.Icon);

        return Task.CompletedTask;
    }
}