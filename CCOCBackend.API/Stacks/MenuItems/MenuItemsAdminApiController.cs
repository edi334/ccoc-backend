using MCMS.Controllers.Api;
using System.Threading.Tasks;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.MenuItems;
[Authorize(Roles = "Admin")]
public class MenuItemsAdminApiController : CrudAdminApiController<MenuItemEntity, MenuItemFormModel, MenuItemViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Parent));
    }

    protected override Task OnCreating(MenuItemEntity e)
    {
        if (e.Parent != null)
            e.Parent = ServiceProvider.GetRepo<MenuItemEntity>().Attach(e.Parent);
        return Task.CompletedTask;
    }
}