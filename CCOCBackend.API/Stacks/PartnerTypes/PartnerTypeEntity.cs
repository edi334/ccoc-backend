using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.PartnerTypes;
[Table("PartnerTypes")]
public class PartnerTypeEntity : Entity
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Id;
    }
}