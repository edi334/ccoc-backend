using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.PartnerTypes;
[Display(Name = "PartnerType")]
public class PartnerTypeViewModel : ViewModel
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Id;
    }
}