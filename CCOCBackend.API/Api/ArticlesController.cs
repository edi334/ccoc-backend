using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.ArticleTags;
using CCOCBackend.API.Stacks.Tags;
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
public class ArticlesController : ApiController
{
    private IRepository<ArticleEntity> Repo => ServiceProvider.Repo<ArticleEntity>();
    private IRepository<ArticleTagEntity> ATRepo => ServiceProvider.Repo<ArticleTagEntity>();
    private IRepository<TagEntity> TagRepo => ServiceProvider.Repo<TagEntity>();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(a => a.Image));
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var articles = await Repo.GetAll();

        var result = articles
            .OrderByDescending(a => a.PublishDate)
            .Select(a => new ArticleDto 
                {
                    Title = a.Title,
                    Image = a.Image?.PhysicalFullPath,
                    Content = a.Content,
                    PublishDate = a.PublishDate
                }
            );

        return Ok(result);
    }

    [HttpGet("GetLatest")]
    [AllowAnonymous]
    public async Task<ActionResult> GetLastest([FromQuery] int count)
    {
        var articles = await Repo.GetAll();

        var result = articles
            .Take(count)
            .OrderByDescending(a => a.PublishDate)
            .Select(a => new ArticleDto 
            {
                Title = a.Title, 
                Image = a.Image?.PhysicalFullPath, 
                Content = a.Content, 
                PublishDate = a.PublishDate
            });

        return Ok(result);
    }

    [HttpGet("GetByTag")]
    [AllowAnonymous]
    public async Task<ActionResult> GetByTag([FromQuery] string tag)
    {
        var tagEntity = await TagRepo.GetOne(t => t.Name == tag);
        if (tagEntity == null)
            return NotFound();

        var articleTags = await ATRepo.GetAll(at => at.TagId == tagEntity.Id);
        var articles = await Repo.GetAll(a =>
            articleTags.Select(at => at.ArticleId).ToList().Contains(a.Id));

        var result = articles
            .OrderByDescending(a => a.PublishDate)
            .Select(a => new ArticleDto
            {
                Title = a.Title,
                Image = a.Image?.PhysicalFullPath,
                Content = a.Content,
                PublishDate = a.PublishDate
            });
        
        return Ok(result);
    }
}