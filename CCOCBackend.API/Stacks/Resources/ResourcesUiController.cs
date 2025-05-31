using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Resources;
[Authorize(Roles = "Admin")]
[Display(Name = "Reports")]
public class ResourcesUiController : GenericModalAdminUiController<ResourceEntity, ResourceFormModel, ResourceViewModel, ResourcesAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.File));
    }
}