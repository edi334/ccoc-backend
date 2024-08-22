using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Tags;
[Table("Tags")]
public class TagEntity : Entity
{
    public string Name { get; set; }

    public FileEntity Icon { get; set; }

    public override string ToString()
    {
        return Id;
    }
}