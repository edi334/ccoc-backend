using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Partners;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using MCMS.Files.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class PartnersController : ApiController
{
    private IRepository<PartnerEntity> Repo => ServiceProvider.Repo<PartnerEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(a => a.Image));
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var partners = await Repo.GetAll();

        var partnerDtos = partners.Select(p => new PartnerDto
        {
            Name = p.Name,
            Image = FileHelper.GetImagePath(p.Image),
            PartnerType = EnumMapper.PARTNER_TYPE[p.PartnerType],
            Link = p.Link
        });

        return Ok(partnerDtos);
    }
}