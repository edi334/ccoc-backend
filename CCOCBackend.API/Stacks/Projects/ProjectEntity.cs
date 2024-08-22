using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Projects;
[Table("Projects")]
public class ProjectEntity : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return Id;
    }
}