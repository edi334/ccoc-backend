using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Pages;

namespace CCOCBackend.API.Stacks.PageImages;
[Table("PageImages")]
public class PageImageEntity : Entity
{
    public FileEntity Image { get; set; }
    public PageEntity Page { get; set; }

    public override string ToString()
    {
        return Id;
    }
}