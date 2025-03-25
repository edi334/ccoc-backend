using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Stacks.PartnerTypes;

namespace CCOCBackend.API.Stacks.Partners;
[Table("Partners")]
public class PartnerEntity : Entity
{
    public string Name { get; set; }
    public FileEntity Image { get; set; }
    
    public string Link { get; set; }
    
    public PartnerTypeEntity Type { get; set; }

    public override string ToString()
    {
        return Id;
    }
}