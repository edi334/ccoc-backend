using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Services;
[Authorize(Roles = "Admin")]
[Display(Name = "Services")]
public class ServicesUiController : GenericModalAdminUiController<ServiceEntity, ServiceFormModel, ServiceViewModel, ServicesAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
}