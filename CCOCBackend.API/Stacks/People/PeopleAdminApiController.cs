using CCOCBackend.API.Stacks.CarouselPages;
using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.People;
[Authorize(Roles = "Admin")]
public class PeopleAdminApiController : CrudAdminApiController<PersonEntity, PersonFormModel, PersonViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image));
    }
    
    protected override Task OnCreating(PersonEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);

        return Task.CompletedTask;
    }
}