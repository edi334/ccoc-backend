using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.Partners;
public enum PartnerType
{
    [EnumMember(Value = "0")]
    Normal,
    [EnumMember(Value = "1")]
    Institutional,
}