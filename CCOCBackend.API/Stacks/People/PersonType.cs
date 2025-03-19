using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.People;

public enum PersonType
{
    [EnumMember(Value = "0")]
    PersonalAngajat,
    [EnumMember(Value = "1")]
    SefOficiu
}