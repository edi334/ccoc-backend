using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;
using MCMS.Files.Models;
using Newtonsoft.Json;

namespace CCOCBackend.API.Stacks.Services;
[Display(Name = "Service")]
public class ServiceViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)] 
    [DetailsField]
    public string Name { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)] 
    [DetailsField]
    public string Description { get; set; }
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public string FormLink { get; set; }

    [Display(Name = "FormLink")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string FormLinkDisplay => FormLink ?? "fără link";
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel Image { get; set; }

    [Display(Name = "Image")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ImageDisplay => 
        $"<img style='max-height: 150px' src='{(string.IsNullOrEmpty(Image?.Url) ? "/img/device-placeholder.svg" : Image.Url)}' alt=' ' class='thumb-image' />";

    public override string ToString()
    {
        return Id;
    }
}