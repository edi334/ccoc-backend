using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Tags;
[Authorize(Roles = "Admin")]
[Display(Name = "Tags")]
public class TagsUiController : GenericModalAdminUiController<TagEntity, TagFormModel, TagViewModel, TagsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Icon));
    }
}