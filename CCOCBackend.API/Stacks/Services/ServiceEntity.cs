using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Services;
[Table("Services")]
public class ServiceEntity : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }
    
    public string FormLink { get; set; }
    
    public FileEntity Image { get; set; }

    public override string ToString()
    {
        return Id;
    }
}