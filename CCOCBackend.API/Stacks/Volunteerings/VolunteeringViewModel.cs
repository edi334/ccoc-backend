using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Volunteerings;
[Display(Name = "Volunteering")]
public class VolunteeringViewModel : ViewModel
{
    public string Name { get; set; }
    public string Text { get; set; }
    public string LinkTo { get; set; }
    
    public override string ToString()
    {
        return Id;
    }
}