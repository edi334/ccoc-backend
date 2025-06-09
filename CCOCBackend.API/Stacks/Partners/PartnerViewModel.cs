using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.PartnerTypes;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.Partners;
[Display(Name = "Partner")]
public class PartnerViewModel : ViewModel
{
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
        $"<img style='max-height: 150px' src='{(string.IsNullOrEmpty(Image?.Url) ? "/img/device-placeholder.svg" : Image.Url)}' alt=' ' class='thumb-image' />";

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public PartnerTypeViewModel Type { get; set; }

    [Display(Name = "Type")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string TypeDisplay => Type != null ? Type.Name : "Fără tip";
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public string Link { get; set; }

    [Display(Name = "Link")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string LinkDisplay => Link ?? "fără link";
    
    public override string ToString()
    {
        return Id;
    }
}