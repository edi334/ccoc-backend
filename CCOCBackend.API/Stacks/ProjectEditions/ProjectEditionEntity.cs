using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Stacks.Projects;

namespace CCOCBackend.API.Stacks.ProjectEditions;
[Table("ProjectEditions")]
public class ProjectEditionEntity : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ProjectEntity Project { get; set; }

    public override string ToString()
    {
        return Id;
    }
}