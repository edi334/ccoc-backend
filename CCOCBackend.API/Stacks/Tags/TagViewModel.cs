using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.Tags;
[Display(Name = "Tag")]
public class TagViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Name { get; set; }

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel Icon { get; set; }
    
    [Display(Name = "Icon")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string IconDisplay => 
        $"<img src='{(string.IsNullOrEmpty(Icon?.Url) ? "/img/device-placeholder.svg" : Icon.Url)}' alt=' ' class='thumb-image' />";

    public override string ToString()
    {
        return Id;
    }
}