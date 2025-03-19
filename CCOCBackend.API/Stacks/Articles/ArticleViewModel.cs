using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.Articles;
[Display(Name = "Article")]
public class ArticleViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Title { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)] 
    [DetailsField]
    public string Slug { get; set; }

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel Image { get; set; }
    
    [Display(Name = "Image")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ImageDisplay => 
        $"<img src='{(string.IsNullOrEmpty(Image?.Url) ? "/img/device-placeholder.svg" : Image.Url)}' alt=' ' class='thumb-image' />";
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Content { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public DateTime PublishDate { get; set; }

    public override string ToString()
    {
        return Id;
    }
}