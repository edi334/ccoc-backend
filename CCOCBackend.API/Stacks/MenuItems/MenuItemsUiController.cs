using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.MenuItems;
[Authorize(Roles = "Admin")]
[Display(Name = "MenuItems")]
public class MenuItemsUiController : GenericModalAdminUiController<MenuItemEntity, MenuItemFormModel, MenuItemViewModel, MenuItemsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Parent));
    }
}