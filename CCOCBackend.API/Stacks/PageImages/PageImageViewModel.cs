using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Pages;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.PageImages;
[Display(Name = "PageImage")]
public class PageImageViewModel : ViewModel
{
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public PageViewModel Page { get; set; }
    
    [Display(Name = "Page")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string PageDisplay => Page.Name;
    
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