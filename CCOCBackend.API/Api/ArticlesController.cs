using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.ArticleTags;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using MCMS.Files;
using MCMS.Files.Models;
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
    public async Task<ActionResult> Get([FromQuery] int? count = null)
    {
        var articles = await Repo.GetAll();

        var articleDtos = new List<ArticleDto>();

        foreach (var article in articles)
        {
            var articleTags = await ATRepo
                .GetAll(at => at.ArticleId == article.Id);
            var tagIds = articleTags.Select(at => at.TagId);
            var tags = await TagRepo.GetAll(t => tagIds.Contains(t.Id));
            var tagDtos = tags.Select(t => new TagDto
            {
                Name = t.Name,
                HexColor = t.HexColor
            });
            
            articleDtos.Add(new ArticleDto
            {
                Title = article.Title,
                Image = FileHelper.GetImagePath(article.Image),
                Content = article.Content,
                PublishDate = article.PublishDate,
                Slug = article.Slug,
                Tags = tagDtos
            });
        }

        var sortedArticles = articleDtos.OrderByDescending(a => a.PublishDate);

        if (count.HasValue)
        {
            return Ok(sortedArticles.Take(count.Value).ToList());
        }

        return Ok(sortedArticles);
    }

    [HttpGet("GetByTag")]
    [AllowAnonymous]
    public async Task<ActionResult> GetByTag([FromQuery] string tag, [FromQuery] int? count = null)
    {
        var tagEntity = await TagRepo.GetOne(t => t.Name == tag);
        if (tagEntity == null)
            return NotFound();

        var articleTags = await ATRepo.GetAll(at => at.TagId == tagEntity.Id);
        var articles = await Repo.GetAll(a =>
            articleTags.Select(at => at.ArticleId).ToList().Contains(a.Id));

        var sortedArticles = articles
            .OrderByDescending(a => a.PublishDate)
            .Select(a => new ArticleDto
            {
                Title = a.Title,
                Image = FileHelper.GetImagePath(a.Image),
                Content = a.Content,
                PublishDate = a.PublishDate,
                Slug = a.Slug
            });

        if (count.HasValue)
        {
            return Ok(sortedArticles.Take(count.Value).ToList());
        }
        
        return Ok(sortedArticles);
    }

    [HttpGet("GetBySlug")]
    [AllowAnonymous]
    public async Task<ActionResult> GetBySlug([FromQuery] string slug)
    {
        var article = await Repo.GetOne(a => a.Slug == slug);

        if (article is null)
        {
            return NotFound();
        }

        var articleTags = await ATRepo
            .GetAll(at => at.ArticleId == article.Id);

        var tagIds = articleTags.Select(at => at.TagId);
        var tags = await TagRepo.GetAll(t => tagIds.Contains(t.Id));
        var tagDtos = tags.Select(t => new TagDto
        {
            Name = t.Name,
            HexColor = t.HexColor
        });

        return Ok(new ArticleDto
        {
            Title = article.Title,
            Image = FileHelper.GetImagePath(article.Image),
            Content = article.Content,
            PublishDate = article.PublishDate,
            Slug = article.Slug,
            Tags = tagDtos
        });
    }
}