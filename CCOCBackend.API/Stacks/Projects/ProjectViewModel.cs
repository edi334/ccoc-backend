using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Projects;
[Display(Name = "Project")]
public class ProjectViewModel : ViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return Id;
    }
}