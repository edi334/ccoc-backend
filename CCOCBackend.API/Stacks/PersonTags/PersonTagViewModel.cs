using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PTags;

namespace CCOCBackend.API.Stacks.PersonTags;
[Display(Name = "PersonTag")]
public class PersonTagViewModel : ViewModel
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public PersonViewModel Person { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public PTagViewModel PTag { get; set; }

    public override string ToString()
    {
        return Id;
    }
}