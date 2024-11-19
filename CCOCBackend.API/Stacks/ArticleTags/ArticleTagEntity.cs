using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.Tags;

namespace CCOCBackend.API.Stacks.ArticleTags;
[Table("ArticleTags")]
public class ArticleTagEntity : Entity
{
    [ForeignKey("Article")] public string ArticleId { get; set; }
    public ArticleEntity Article { get; set; }

    [ForeignKey("Tag")] public string TagId { get; set; }
    public TagEntity Tag { get; set; }

    public override string ToString()
    {
        return Id;
    }
}