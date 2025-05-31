using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.Resources;
public enum ResourceType
{
    [EnumMember(Value = "0")]
    Plan,
    [EnumMember(Value = "1")]
    Raport,
    [EnumMember(Value = "2")]
    Altele
}