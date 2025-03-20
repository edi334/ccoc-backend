using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Projects;
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
public class ProjectsController : ApiController
{
    private IRepository<ProjectEntity> Repo => ServiceProvider.Repo<ProjectEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(p => p.TitleImage));
        Repo.ChainQueryable(q => q.Include(p => p.PresentationImage));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var projects = await Repo.GetAll();

        var result = projects.Select(p => new ProjectDto
        {
            Title = p.Title,
            Description = p.Description,
            Type = EnumMapper.PROJECT_TYPE[p.Type],
            Slug = p.Slug,
            TitleImage = FileHelper.GetImagePath(p.TitleImage),
            PresentationImage = FileHelper.GetImagePath(p.PresentationImage)
        });

        return Ok(result);
    }

    [HttpGet("GetBySlug")]
    [AllowAnonymous]
    public async Task<ActionResult> GetBySlug([FromQuery] string slug)
    {
        var project = await Repo.GetOne(a => a.Slug == slug);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(new ProjectDto
        {
            Title = project.Title,
            Description = project.Description,
            Type = EnumMapper.PROJECT_TYPE[project.Type],
            Slug = project.Slug,
            TitleImage = FileHelper.GetImagePath(project.TitleImage),
            PresentationImage = FileHelper.GetImagePath(project.PresentationImage)
        });
    }
}