using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.Partners;
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
public class PartnersController : ApiController
{
    private IRepository<PartnerEntity> Repo => ServiceProvider.Repo<PartnerEntity>();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => 
            q.Include(a => a.Image).Include(a => a.Type));
    }

    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var partners = await Repo.GetAll();

        var partnerDtos = partners.Select(p =>
        {
            var dto =  new PartnerDto
            {
                Name = p.Name,
                Image = FileHelper.GetImagePath(p.Image),
                PartnerType = p.Type.Name
            };

            if (p.Link is not null)
            {
                dto.Link = p.Link;
            }

            return dto;
        });

        return Ok(partnerDtos);
    }
}