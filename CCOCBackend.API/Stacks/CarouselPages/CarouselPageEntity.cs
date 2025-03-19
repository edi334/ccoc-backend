using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.CarouselPages;
[Table("CarouselPages")]
public class CarouselPageEntity : Entity
{
    public FileEntity Image { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public bool Enabled { get; set; }
    
    public string LinkTo { get; set; }

    public override string ToString()
    {
        return Id;
    }
}