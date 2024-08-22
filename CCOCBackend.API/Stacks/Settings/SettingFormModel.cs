using MCMS.Base.Data.FormModels;

namespace CCOCBackend.API.Stacks.Settings;
public class SettingFormModel : IFormModel
{
    public string Name { get; set; }

    public string Value { get; set; }
}