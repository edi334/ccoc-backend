using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Services;
[Authorize(Roles = "Admin")]
public class ServicesAdminApiController : CrudAdminApiController<ServiceEntity, ServiceFormModel, ServiceViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
    
    protected override Task OnCreating(ServiceEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);

        return Task.CompletedTask;
    }
}