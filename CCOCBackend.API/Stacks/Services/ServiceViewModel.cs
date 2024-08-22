using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Services;
[Display(Name = "Service")]
public class ServiceViewModel : ViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return Id;
    }
}