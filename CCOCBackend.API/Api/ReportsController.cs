using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Reports;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class ReportsController : ApiController
{
    private IRepository<ReportEntity> Repo => ServiceProvider.Repo<ReportEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(r => r.File));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var reports = await Repo.GetAll();

        var result = reports.Select(r => new ReportDto
            {
                Description = r.Description,
                Year = r.Year,
                Type = EnumMapper.REPORT_TYPE[r.Type],
                File = FileHelper.GetImagePath(r.File)
            }
        );
        
        return Ok(result);
    }
}