using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Services;
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
public class ServicesController : ApiController
{
    private IRepository<ServiceEntity> Repo => ServiceProvider.Repo<ServiceEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(s => s.Image));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var services = await Repo.GetAll();

        var result = services.Select(s =>
        {
            var dto = new ServiceDto
            {
                Name = s.Name,
                Description = s.Description,
                Image = FileHelper.GetImagePath(s.Image)
            };

            if (s.FormLink is not null)
            {
                dto.FormLink = s.FormLink;
            }

            return dto;
        });
        
        return Ok(result);
    }
}