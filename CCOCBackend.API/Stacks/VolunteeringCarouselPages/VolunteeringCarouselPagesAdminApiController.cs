using MCMS.Controllers.Api;
using System.Threading.Tasks;
using CCOCBackend.API.Stacks.Volunteerings;
using MCMS.Base.Extensions;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.VolunteeringCarouselPages;
[Authorize(Roles = "Admin")]
public class VolunteeringCarouselPagesAdminApiController : CrudAdminApiController<VolunteeringCarouselPageEntity, VolunteeringCarouselPageFormModel, VolunteeringCarouselPageViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image).Include(c => c.Volunteering));
    }

    protected override Task OnCreating(VolunteeringCarouselPageEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);
        if (e.Volunteering != null)
            e.Volunteering = ServiceProvider.GetRepo<VolunteeringEntity>().Attach(e.Volunteering);
        return Task.CompletedTask;
    }
}