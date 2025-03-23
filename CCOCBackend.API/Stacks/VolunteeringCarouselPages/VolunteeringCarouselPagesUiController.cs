using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.VolunteeringCarouselPages;
[Authorize(Roles = "Admin")]
[Display(Name = "VolunteeringCarouselPages")]
public class VolunteeringCarouselPagesUiController : GenericModalAdminUiController<VolunteeringCarouselPageEntity, VolunteeringCarouselPageFormModel, VolunteeringCarouselPageViewModel, VolunteeringCarouselPagesAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image).Include(c => c.Volunteering));
    }
}