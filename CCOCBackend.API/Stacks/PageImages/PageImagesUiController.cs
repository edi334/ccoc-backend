using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PageImages;
[Authorize(Roles = "Admin")]
[Display(Name = "PageImages")]
public class PageImagesUiController : GenericModalAdminUiController<PageImageEntity, PageImageFormModel, PageImageViewModel, PageImagesAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image).Include(c => c.Page));
    }
}