using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Stacks.PTags;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class PersonTagsController: ApiController
{
    private IRepository<PTagEntity> Repo => ServiceProvider.Repo<PTagEntity>();
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var pTags = await Repo.GetAll();

        var result = pTags.Select(t => new TagDto {Name = t.Name, HexColor = t.HexColor});
        return Ok(result);
    }
}