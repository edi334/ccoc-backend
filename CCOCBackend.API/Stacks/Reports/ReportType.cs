using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.Reports;
public enum ReportType
{
    [EnumMember(Value = "0")]
    Plan,
    Report,
}