using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.PTags;
[Table("PTags")]
public class PTagEntity : Entity
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Id;
    }
}