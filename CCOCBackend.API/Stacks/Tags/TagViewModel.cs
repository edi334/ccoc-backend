using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Tags;
[Display(Name = "Tag")]
public class TagViewModel : ViewModel
{
    public string Name { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public FileViewModel Icon { get; set; }

    public override string ToString()
    {
        return Id;
    }
}