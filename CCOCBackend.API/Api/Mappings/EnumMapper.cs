using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.Projects;
using CCOCBackend.API.Stacks.Resources;

namespace CCOCBackend.API.Api.Mappings;

public static class EnumMapper
{
    public static Dictionary<PersonType, string> PERSON_TYPE = new()
    {
        {PersonType.PersonalAngajat, "angajat"},
        {PersonType.SefOficiu, "sef-oficiu"}
    };
    
    public static Dictionary<ResourceType, string> RESOURCE_TYPE = new()
    {
        {ResourceType.Plan, "plan"},
        {ResourceType.Raport, "raport"},
        {ResourceType.Altele, "altele"}
    };
    
    public static Dictionary<ProjectType, string> PROJECT_TYPE = new()
    {
        {ProjectType.Project, "proiect"},
        {ProjectType.Event, "eveniment"}
    };
}