using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.MenuItems;
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
public class MenuItemsController : ApiController
{
    private IRepository<MenuItemEntity> Repo => ServiceProvider.Repo<MenuItemEntity>();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(mi => mi.Parent));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var items = await Repo.GetAll();
        var children = items.Where(a => a.Parent != null);
        var parents = items.Where(a => a.Parent == null)
            .Select(a => new MenuItemDto
            {
                Link = a.Link,
                Name = a.Name,
                Children = children.Where(x => x.Parent.Id == a.Id).Select(x => 
                    new MenuItemDto{ Name = x.Name, Link = x.Link })
            });
        
        return Ok(parents);
    }
}