using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PTags;
using MCMS.Controllers.Api;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PersonTags;
[Authorize(Roles = "Admin")]
public class PersonTagsAdminApiController : CrudAdminApiController<PersonTagEntity, PersonTagFormModel, PersonTagViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Person).Include(c => c.PTag));
    }

    protected override Task OnCreating(PersonTagEntity e)
    {
        if (e.Person != null)
            e.Person = ServiceProvider.GetRepo<PersonEntity>().Attach(e.Person);
        if (e.PTag != null)
            e.PTag = ServiceProvider.GetRepo<PTagEntity>().Attach(e.PTag);
        return Task.CompletedTask;
    }
}