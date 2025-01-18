using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Shortcuts;
[Authorize(Roles = "Admin")]
[Display(Name = "Shortcuts")]
public class ShortcutsUiController : GenericModalAdminUiController<ShortcutEntity, ShortcutFormModel, ShortcutViewModel, ShortcutsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
}