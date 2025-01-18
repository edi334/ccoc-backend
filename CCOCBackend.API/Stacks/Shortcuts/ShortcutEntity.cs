using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Shortcuts;
[Table("Shortcuts")]
public class ShortcutEntity : Entity
{
    public string Name { get; set; }

    public FileEntity Image { get; set; }

    public bool Enabled { get; set; }

    public string Link { get; set; }

    public override string ToString()
    {
        return Id;
    }
}