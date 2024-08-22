using MCMS.Base.Data.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Settings;
[Display(Name = "Setting")]
public class SettingViewModel : ViewModel
{
    public string Name { get; set; }

    public string Value { get; set; }

    public override string ToString()
    {
        return Id;
    }
}