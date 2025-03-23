using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace  CCOCBackend.API.Stacks.Volunteerings;

[Table("Volunteerings")]
public class VolunteeringEntity : Entity
{
    public string Name { get; set; }
    public string Text { get; set; }
    public string LinkTo { get; set; }

    public override string ToString()
    { 
        return Id;
    }
}