using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.Reports;
[Display(Name = "Report")]
public class ReportViewModel : ViewModel
{
    public string Name { get; set; }

    public string Year { get; set; }

    public ReportType Type { get; set; }

    [JsonConverter(typeof(ToStringJsonConverter))]
    public FileViewModel File { get; set; }

    public override string ToString()
    {
        return Id;
    }
}