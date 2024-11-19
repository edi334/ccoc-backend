using CCOCBackend.API.Stacks.CarouselPages;
using MCMS.Base.Extensions;
using MCMS.Controllers.Api;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Stacks.Reports;
[Authorize(Roles = "Admin")]
public class ReportsAdminApiController : CrudAdminApiController<ReportEntity, ReportFormModel, ReportViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.File));
    }
    
    protected override Task OnCreating(ReportEntity e)
    {
        if (e.File != null)
            e.File = ServiceProvider.GetRepo<FileEntity>().Attach(e.File);

        return Task.CompletedTask;
    }
}