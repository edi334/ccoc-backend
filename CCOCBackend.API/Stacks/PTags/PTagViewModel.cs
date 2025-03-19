using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.PTags;
[Display(Name = "PTag")]
public class PTagViewModel : ViewModel
{
    public string Name { get; set; }
    
    public string HexColor { get; set; }

    public override string ToString()
    {
        return Id;
    }
}