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
        Repo.ChainQueryable(q => q.Include(p => p.Parent));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get([FromQuery] string? type = null)
    {
        var projects = await Repo.GetAll();
        
        var projectDtos = projects
            .Where(p => p.Enabled)
            .Select(p => _getProjectWithParents(p));

        if (type is not null)
        {
            var result = projectDtos.Where(p => p.Type == type);
            return Ok(result);
        }
        
        return Ok(projectDtos);
    }
    
    [HttpGet("GetAllParents")]
    [AllowAnonymous]
    public async Task<ActionResult> GetParents([FromQuery] string? type = null)
    {
        var projects = await Repo.GetAll();
        
        var projectDtos = projects
            .Where(p => p.Enabled)
            .Where(p => p.IsParent)
            .Select(p => _getProjectWithParents(p));

        if (type is not null)
        {
            var result = projectDtos.Where(p => p.Type == type);
            return Ok(result);
        }
        
        return Ok(projectDtos);
    }
    
    [HttpGet("GetChildren")]
    [AllowAnonymous]
    public async Task<ActionResult> GetChildren([FromQuery] string parentSlug)
    {
        var projects = await Repo.GetAll(p => p.Parent.Slug == parentSlug);
        
        var result = projects
            .Where(p => p.Enabled)
            .Where(p => !p.IsParent)
            .Select(p => _getProjectWithParents(p));

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
        
        if (!project.Enabled)
        {
            return BadRequest("Project is not enabled!");
        }

        return Ok(_getProjectWithParents(project));
    }

    private ProjectDto _getProjectWithParents(ProjectEntity project)
    {
        var projectDto = new ProjectDto
        {
            Title = project.Title,
            Description = project.Description,
            Type = EnumMapper.PROJECT_TYPE[project.Type],
            Slug = project.Slug,
            IsParent = project.IsParent,
            TitleImage = FileHelper.GetImagePath(project.TitleImage),
            PresentationImage = FileHelper.GetImagePath(project.PresentationImage),
            ExternalUrl = project.ExternalUrl
        };

        if (project.Parent is not null)
        {
            projectDto.Parent = _getProjectWithParents(project.Parent);
        }

        return projectDto;
    }
}