using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Resources;
[Table("Reports")]
public class ResourceEntity : Entity
{
    public string Description { get; set; }

    public int Year { get; set; }

    public ResourceType Type { get; set; }

    public FileEntity File { get; set; }
    
    public string Authors { get; set; }

    public override string ToString()
    {
        return Id;
    }
}