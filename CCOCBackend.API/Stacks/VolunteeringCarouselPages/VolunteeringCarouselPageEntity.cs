using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Stacks.Volunteerings;

namespace CCOCBackend.API.Stacks.VolunteeringCarouselPages;
[Table("VolunteeringCarouselPages")]
public class VolunteeringCarouselPageEntity : Entity
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public FileEntity Image { get; set; }
    public VolunteeringEntity Volunteering { get; set; }

    public override string ToString()
    {
        return Id;
    }
}