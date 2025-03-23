using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Pages;
[Display(Name = "Page")]
public class PageViewModel : ViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }

    public override string ToString()
    {
        return Id;
    }
}