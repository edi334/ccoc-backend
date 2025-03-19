using MCMS.Base.Data.FormModels;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;

namespace CCOCBackend.API.Stacks.Tags;
public class TagFormModel : IFormModel
{
    public string Name { get; set; }

    public string HexColor { get; set; }
}