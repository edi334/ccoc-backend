using MCMS.Controllers.Api;
using System.Threading.Tasks;
using CCOCBackend.API.Stacks.PartnerTypes;
using MCMS.Base.Extensions;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Partners;
[Authorize(Roles = "Admin")]
public class PartnersAdminApiController : CrudAdminApiController<PartnerEntity, PartnerFormModel, PartnerViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
        Repo.ChainQueryable(q => q.Include(c => c.Type));
    }

    protected override Task OnCreating(PartnerEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);
        if (e.Type != null)
            e.Type = ServiceProvider.GetRepo<PartnerTypeEntity>().Attach(e.Type);
        return Task.CompletedTask;
    }
}