using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Pages;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class PageController : ApiController
{
    private IRepository<PageEntity> Repo => ServiceProvider.Repo<PageEntity>();
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var pages = await Repo.GetAll();

        var result = pages.Select(p => new PageDto
        {
            Name = p.Name,
            Description = p.Description,
            Slug = p.Slug
        });
        
        return Ok(result);
    }
    
    [HttpGet("GetBySlug")]
    [AllowAnonymous]
    public async Task<ActionResult> GetBySlug([FromQuery] string slug)
    {
        var page = await Repo.GetOne(a => a.Slug == slug);

        if (page is null)
        {
            return NotFound();
        }

        return Ok(new PageDto()
        {
            Name = page.Name,
            Description = page.Description,
            Slug = page.Slug
        });
    }
}