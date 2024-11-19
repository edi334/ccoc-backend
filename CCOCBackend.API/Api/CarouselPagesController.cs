using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.CarouselPages;
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
public class CarouselPagesController : ApiController
{
    private IRepository<CarouselPageEntity> Repo => ServiceProvider.Repo<CarouselPageEntity>();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(p => p.Include(a => a.Image));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var pages = await Repo.GetAll(p => p.Enabled);
        var result = pages
            .Select(p => new CarouselPageDto
            {
                Name = p.Name,
                Image = p.Image?.PhysicalFullPath,
            });

        return Ok(result);
    }
}