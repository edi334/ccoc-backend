using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.People;
[Display(Name = "Person")]
public class PersonViewModel : ViewModel
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public FileViewModel Image { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Information { get; set; }
    
    public PersonType PersonType { get; set; }
    
    public override string ToString()
    {
        return Id;
    }
}