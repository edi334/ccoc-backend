using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;
using MCMS.Files.Models;
using Newtonsoft.Json;

namespace CCOCBackend.API.Stacks.Projects;
[Display(Name = "Project")]
public class ProjectViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Title { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Description { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public ProjectType Type { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Slug { get; set; }
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel TitleImage { get; set; }
    
    [Display(Name = "TitleImage")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string TitleImageDisplay => 
        $"<img src='{(string.IsNullOrEmpty(TitleImage?.Url) ? "/img/device-placeholder.svg" : TitleImage.Url)}' alt=' ' class='thumb-image' />";
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel PresentationImage { get; set; }
    
    [Display(Name = "PresentationImage")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string PresentationImageDisplay => 
        $"<img src='{(string.IsNullOrEmpty(PresentationImage?.Url) ? "/img/device-placeholder.svg" : PresentationImage.Url)}' alt=' ' class='thumb-image' />";

    public override string ToString()
    {
        return Id;
    }
}