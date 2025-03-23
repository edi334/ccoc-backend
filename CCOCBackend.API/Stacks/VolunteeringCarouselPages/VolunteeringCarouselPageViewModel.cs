using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.Volunteerings;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.VolunteeringCarouselPages;
[Display(Name = "VolunteeringCarouselPage")]
public class VolunteeringCarouselPageViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)] 
    [DetailsField]
    public bool Enabled { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)] 
    [DetailsField]
    public string Name { get; set; }

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel Image { get; set; }
    
    [Display(Name = "Image")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ImageDisplay => 
        $"<img src='{(string.IsNullOrEmpty(Image?.Url) ? "/img/device-placeholder.svg" : Image.Url)}' alt=' ' class='thumb-image' />";


    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public VolunteeringViewModel Volunteering { get; set; }

    [Display(Name = "Volunteering")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string VolunteeringDisplay => Volunteering.Name;

    public override string ToString()
    {
        return Id;
    }
}