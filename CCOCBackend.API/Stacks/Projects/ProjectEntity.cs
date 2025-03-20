using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Projects;
[Table("Projects")]
public class ProjectEntity : Entity
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public ProjectType Type { get; set; }
    
    public string Slug { get; set; }
    
    public FileEntity TitleImage { get; set; }
    
    public FileEntity PresentationImage { get; set; }

    public override string ToString()
    {
        return Id;
    }
}