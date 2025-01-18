using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.ArticleTags;
[Display(Name = "ArticleTag")]
public class ArticleTagViewModel : ViewModel
{
    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public ArticleViewModel Article { get; set; }
    
    [Display(Name = "Article")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string ArticleDisplay => Article.Title;

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public TagViewModel Tag { get; set; }
    
    [Display(Name = "Tag")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string TagDisplay => Tag.Name;

    public override string ToString()
    {
        return Id;
    }
}