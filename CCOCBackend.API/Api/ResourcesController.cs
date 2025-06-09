using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Resources;
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
public class ResourcesController : ApiController
{
    private IRepository<ResourceEntity> Repo => ServiceProvider.Repo<ResourceEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(r => r.File));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var resources = await Repo.GetAll();

        var result = resources.Select(r => new ResourceDto
            {
                Description = r.Description,
                Year = r.Year,
                Type = EnumMapper.RESOURCE_TYPE[r.Type],
                Authors = r.Authors,
                File = FileHelper.GetImagePath(r.File),
                Title = r.Title,
                Subtype = r.Subtype
            }
        );
        
        return Ok(result);
    }
    
    [HttpGet("GetByType")]
    [AllowAnonymous]
    public async Task<ActionResult> GetByType([FromQuery] string type)
    {
        var reversedTypeMap = EnumMapper.RESOURCE_TYPE.ToDictionary(pair => pair.Value, pair => pair.Key);

        if (!reversedTypeMap.ContainsKey(type))
        {
            return BadRequest("Invalid type!");
        }
        
        var reports = await Repo.GetAll(r => r.Type == reversedTypeMap[type]);

        var result = reports.Select(r => new ResourceDto
            {
                Description = r.Description,
                Year = r.Year,
                Type = EnumMapper.RESOURCE_TYPE[r.Type],
                Authors = r.Authors,
                File = FileHelper.GetImagePath(r.File),
                Title = r.Title,
                Subtype = r.Subtype
            }
        );
        
        return Ok(result);
    }
}