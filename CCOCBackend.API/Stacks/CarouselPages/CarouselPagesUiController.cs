using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.CarouselPages;
[Authorize(Roles = "Admin")]
[Display(Name = "CarouselPages")]
public class CarouselPagesUiController : GenericModalAdminUiController<CarouselPageEntity, CarouselPageFormModel, CarouselPageViewModel, CarouselPagesAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
}