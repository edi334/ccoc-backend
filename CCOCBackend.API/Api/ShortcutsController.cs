using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.Shortcuts;
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
public class ShortcutsController : ApiController
{
    private IRepository<ShortcutEntity> Repo => ServiceProvider.Repo<ShortcutEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(p => p.Include(a => a.Image));
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var shortcuts = await Repo.GetAll(p => p.Enabled);
        var result = shortcuts
            .Select(p => new ShortcutDto
            {
                Name = p.Name,
                Link = p.Link,
                Image = p.Image?.PhysicalFullPath,
            });

        return Ok(result);
    }
}