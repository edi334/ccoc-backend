using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.CarouselPages;
[Authorize(Roles = "Admin")]
public class CarouselPagesAdminApiController : CrudAdminApiController<CarouselPageEntity, CarouselPageFormModel, CarouselPageViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
    
    protected override Task OnCreating(CarouselPageEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);

        return Task.CompletedTask;
    }
}