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
    public bool Enabled { get; set; }
    
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
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public bool IsParent { get; set; }
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public ProjectViewModel Parent { get; set; }

    [Display(Name = "Parent")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ParentDisplay => Parent?.Title ?? "No parent";
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ExternalUrl { get; set; }
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel TitleImage { get; set; }
    
    [Display(Name = "TitleImage")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string TitleImageDisplay => 
        $"<img style='max-height: 150px' src='{(string.IsNullOrEmpty(TitleImage?.Url) ? "/img/device-placeholder.svg" : TitleImage.Url)}' alt=' ' class='thumb-image' />";
    
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel PresentationImage { get; set; }
    
    [Display(Name = "PresentationImage")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string PresentationImageDisplay => 
        $"<img style='max-height: 150px' src='{(string.IsNullOrEmpty(PresentationImage?.Url) ? "/img/device-placeholder.svg" : PresentationImage.Url)}' alt=' ' class='thumb-image' />";

    public override string ToString()
    {
        return Id;
    }
}