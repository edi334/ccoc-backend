using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.Api.Stacks.VolunteeringBenefits;
using CCOCBackend.API.Stacks.VolunteeringCarouselPages;
using CCOCBackend.API.Stacks.Volunteerings;
using MCMS.Auth.Controllers;
using MCMS.Base.Attributes;
using MCMS.Base.Data;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCOCBackend.API.Api;

[ApiRoute("[controller]")]
public class VolunteeringController : ApiController
{
    private IRepository<VolunteeringEntity> Repo => ServiceProvider.Repo<VolunteeringEntity>();
    private IRepository<VolunteeringCarouselPageEntity> CarouselPagesRepo => ServiceProvider.Repo<VolunteeringCarouselPageEntity>();
    private IRepository<VolunteeringBenefitEntity> BenefitsRepo => ServiceProvider.Repo<VolunteeringBenefitEntity>();

    [HttpGet("Get")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var volunteerings = await Repo.GetAll();

        if (volunteerings.Count == 0)
        {
            return NotFound();
        }

        var volunteering = volunteerings.First();

        var benefits = await BenefitsRepo
            .ChainQueryable(b =>
                b.Include(x => x.Image).Include(x => x.Volunteering))
            .GetAll(b => b.Volunteering.Id == volunteering.Id);

        var benefitDtos = benefits.Select(b => new VolunteeringBenefitDto
        {
            Name = b.Name,
            Image = FileHelper.GetImagePath(b.Image)
        });
        
        var carouselPages = await CarouselPagesRepo
            .ChainQueryable(c =>
                c.Include(x => x.Image).Include(x => x.Volunteering))
            .GetAll(c => c.Volunteering.Id == volunteering.Id && c.Enabled == true);

        var carouselPageDtos = carouselPages.Select(b => new VolunteeringCarouselPageDto
        {
            Name = b.Name,
            Image = FileHelper.GetImagePath(b.Image)
        });

        var result = new VolunteeringDto
        {
            Name = volunteering.Name,
            LinkTo = volunteering.LinkTo,
            Text = volunteering.Text,
            Benefits = benefitDtos,
            CarouselPages = carouselPageDtos
        };

        return Ok(result);

    }
}