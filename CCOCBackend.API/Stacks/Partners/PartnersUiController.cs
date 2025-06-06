using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Partners;
[Authorize(Roles = "Admin")]
[Display(Name = "Partners")]
public class PartnersUiController : GenericModalAdminUiController<PartnerEntity, PartnerFormModel, PartnerViewModel, PartnersAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
        Repo.ChainQueryable(q => q.Include(c => c.Type));
    }
}