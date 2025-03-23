using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Pages;
[Table("Pages")]
public class PageEntity : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public override string ToString()
    {
        return Id;
    }
}