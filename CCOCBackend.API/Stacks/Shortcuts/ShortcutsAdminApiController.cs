using MCMS.Controllers.Api;
using System.Threading.Tasks;
using MCMS.Base.Data.Entities;
using MCMS.Base.Extensions;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Shortcuts;
[Authorize(Roles = "Admin")]
public class ShortcutsAdminApiController : CrudAdminApiController<ShortcutEntity, ShortcutFormModel, ShortcutViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }

    protected override Task OnCreating(ShortcutEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);
        return Task.CompletedTask;
    }
}