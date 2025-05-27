using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.People;
[Display(Name = "Person")]
public class PersonViewModel : ViewModel
{
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel Image { get; set; }
    
    [Display(Name = "Image")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ImageDisplay => 
        $"<img style='max-height: 150px' src='{(string.IsNullOrEmpty(Image?.Url) ? "/img/device-placeholder.svg" : Image.Url)}' alt=' ' class='thumb-image' />";

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string FirstName { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string LastName { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string PhoneNumber { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Email { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Location { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public PersonType Type { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Description { get; set; }
    
    public override string ToString()
    {
        return Id;
    }
}