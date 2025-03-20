using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.Projects;

public enum ProjectType
{
    [EnumMember(Value = "0")]
    Project,
    [EnumMember(Value = "1")]
    Event,
}