using System.Runtime.Serialization;

namespace CCOCBackend.API.Stacks.Reports;
public enum ReportType
{
    [EnumMember(Value = "0")]
    Plan,
    [EnumMember(Value = "1")]
    Raport,
}