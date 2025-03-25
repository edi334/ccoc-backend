using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Pages;
using CCOCBackend.API.Stacks.PageImages;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class PageController : ApiController
{
    private IRepository<PageEntity> Repo => ServiceProvider.Repo<PageEntity>();
    private IRepository<PageImageEntity> PageImagesRepo => ServiceProvider.Repo<PageImageEntity>();
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var pages = await Repo.GetAll();
        var result = new List<PageDto>();

        foreach (var page in pages)
        {
            var images = await PageImagesRepo
                .ChainQueryable(pi => pi.Include(x => x.Page).Include(x => x.Image))
                .GetAll(i => i.Page.Id == page.Id);

            var imageLinks = images.Select(i => FileHelper.GetImagePath(i.Image));

            var pageDto = new PageDto
            {
                Name = page.Name,
                Description = page.Description,
                Slug = page.Slug,
                ShortDescription = page.ShortDescription,
                Images = imageLinks
            };

            result.Add(pageDto);
        }
        
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
        
        var images = await PageImagesRepo
            .ChainQueryable(pi => pi.Include(x => x.Page).Include(x => x.Image))
            .GetAll(i => i.Page.Id == page.Id);

        var imageLinks = images.Select(i => FileHelper.GetImagePath(i.Image));

        return Ok(new PageDto()
        {
            Name = page.Name,
            Description = page.Description,
            Slug = page.Slug,
            ShortDescription = page.ShortDescription,
            Images = imageLinks
        });
    }
}