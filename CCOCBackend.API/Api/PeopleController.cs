using CCOCBackend.API.Api.Dtos;
using CCOCBackend.API.Api.Mappings;
using CCOCBackend.API.Api.Utils;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PersonTags;
using CCOCBackend.API.Stacks.PTags;
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
public class PeopleController : ApiController
{
    private IRepository<PersonEntity> Repo => ServiceProvider.Repo<PersonEntity>();
    private IRepository<PersonTagEntity> PTRepo => ServiceProvider.Repo<PersonTagEntity>();
    private IRepository<PTagEntity> PTagRepo => ServiceProvider.Repo<PTagEntity>();
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(a => a.Image));
    }
    
    [HttpGet("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> Get()
    {
        var people = await Repo.GetAll();
        var peopleDtos = await GetPeopleWithTags(people);
        return Ok(peopleDtos);
    }

    [HttpGet("GetByTag")]
    [AllowAnonymous]
    public async Task<ActionResult> GetByTag([FromQuery] string tag)
    {
        var pTagEntity = await PTagRepo.GetOne(t => t.Name == tag);
        if (pTagEntity == null)
            return NotFound();

        var personTags = await PTRepo.GetAll(at => at.PTagId == pTagEntity.Id);
        var people = await Repo.GetAll(a =>
            personTags.Select(at => at.PersonId).ToList().Contains(a.Id));

        var peopleDtos = await GetPeopleWithTags(people);
        return Ok(peopleDtos);
    }

    private async Task<List<PersonDto>> GetPeopleWithTags(List<PersonEntity> people)
    {
        var peopleDtos = new List<PersonDto>();
        
        foreach (var person in people)
        {
            var personTags = await PTRepo
                .GetAll(pt => pt.PersonId == person.Id);
            var pTagIds = personTags.Select(at => at.PTagId);
            var tags = await PTagRepo.GetAll(t => pTagIds.Contains(t.Id));
            var tagDtos = tags.Select(t => new TagDto
            {
                Name = t.Name,
                HexColor = t.HexColor
            });
            
            peopleDtos.Add(new PersonDto()
            {
                Image = FileHelper.GetImagePath(person.Image),
                Name = person.FirstName + " " + person.LastName,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                Location = person.Location,
                Type = EnumMapper.PERSON_TYPE[person.Type],
                Tags = tagDtos,
                Description = person.Description
            });
        }

        return peopleDtos;
    }
    
}