using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Articles;
[Table("Articles")]
public class ArticleEntity : Entity
{
    public string Title { get; set; }

    public FileEntity Image { get; set; }

    public string Content { get; set; }

    public DateTime PublishDate { get; set; }

    public override string ToString()
    {
        return Id;
    }
}