using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Articles;
[Display(Name = "Article")]
public class ArticleViewModel : ViewModel
{
    public string Title { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public FileViewModel Image { get; set; }

    public string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public override string ToString()
    {
        return Id;
    }
}