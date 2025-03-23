using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.Api.Stacks.VolunteeringBenefits;
[Authorize(Roles = "Admin")]
[Display(Name = "VolunteeringBenefits")]
public class VolunteeringBenefitsUiController : GenericModalAdminUiController<VolunteeringBenefitEntity, VolunteeringBenefitFormModel, VolunteeringBenefitViewModel, VolunteeringBenefitsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image).Include(c => c.Volunteering));
    }
}