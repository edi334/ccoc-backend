using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class TagsController : ApiController
{
    private IRepository<TagEntity> Repo => ServiceProvider.Repo<TagEntity>();
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var tags = await Repo.GetAll();

        var result = tags.Select(t => new TagDto {Name = t.Name, HexColor = t.HexColor});
        return Ok(result);
    }
}