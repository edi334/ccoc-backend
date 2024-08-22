using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.Tags;

namespace CCOCBackend.API.Stacks.ArticleTags;
[Display(Name = "ArticleTag")]
public class ArticleTagViewModel : ViewModel
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public ArticleViewModel Article { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public TagViewModel Tag { get; set; }

    public override string ToString()
    {
        return Id;
    }
}