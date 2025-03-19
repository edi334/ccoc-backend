using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PTags;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.PersonTags;
[Display(Name = "PersonTag")]
public class PersonTagViewModel : ViewModel
{
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public PersonViewModel Person { get; set; }
    
    [Display(Name = "Person")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string PersonDisplay => Person.FirstName + " " + Person.LastName;

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public PTagViewModel PTag { get; set; }
    
    [Display(Name = "PTag")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string TagDisplay => PTag.Name;

    public override string ToString()
    {
        return Id;
    }
}