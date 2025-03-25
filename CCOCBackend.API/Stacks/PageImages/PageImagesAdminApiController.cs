using MCMS.Controllers.Api;
using System.Threading.Tasks;
using CCOCBackend.API.Pages;
using MCMS.Base.Extensions;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PageImages;
[Authorize(Roles = "Admin")]
public class PageImagesAdminApiController : CrudAdminApiController<PageImageEntity, PageImageFormModel, PageImageViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Image).Include(c => c.Page));
    }

    protected override Task OnCreating(PageImageEntity e)
    {
        if (e.Image != null)
            e.Image = ServiceProvider.GetRepo<FileEntity>().Attach(e.Image);
        if (e.Page != null)
            e.Page = ServiceProvider.GetRepo<PageEntity>().Attach(e.Page);
        return Task.CompletedTask;
    }
}