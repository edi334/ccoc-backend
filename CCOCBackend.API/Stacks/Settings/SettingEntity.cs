using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Settings;
[Table("Settings")]
public class SettingEntity : Entity
{
    public string Name { get; set; }

    public string Value { get; set; }

    public override string ToString()
    {
        return Id;
    }
}