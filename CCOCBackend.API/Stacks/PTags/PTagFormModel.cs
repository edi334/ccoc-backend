using MCMS.Base.Data.FormModels;

namespace CCOCBackend.API.Stacks.PTags;
public class PTagFormModel : IFormModel
{
    public string Name { get; set; }
    
    public string HexColor { get; set; }
}