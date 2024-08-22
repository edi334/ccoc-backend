using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.Projects;

namespace CCOCBackend.API.Stacks.ProjectEditions;
[Display(Name = "ProjectEdition")]
public class ProjectEditionViewModel : ViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public ProjectViewModel Project { get; set; }

    public override string ToString()
    {
        return Id;
    }
}