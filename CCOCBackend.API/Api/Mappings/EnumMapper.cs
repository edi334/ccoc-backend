using CCOCBackend.API.Stacks.Partners;
using CCOCBackend.API.Stacks.People;

namespace CCOCBackend.API.Api.Mappings;

public static class EnumMapper
{
    public static Dictionary<PartnerType, string> PARTNER_TYPE = new()
    {
        {PartnerType.Normal, "normal"},
        {PartnerType.Institutional, "institutional"}
    };
    
    public static Dictionary<PersonType, string> PERSON_TYPE = new()
    {
        {PersonType.PersonalAngajat, "angajat"},
        {PersonType.SefOficiu, "sef-oficiu"}
    };
}