using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PersonTags;
[Authorize(Roles = "Admin")]
[Display(Name = "PersonTags")]
public class PersonTagsUiController : GenericModalAdminUiController<PersonTagEntity, PersonTagFormModel, PersonTagViewModel, PersonTagsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Person).Include(c => c.PTag));
    }
}