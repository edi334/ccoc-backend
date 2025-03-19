using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MCMS.Base.Display.ModelDisplay;
using MCMS.Base.Display.ModelDisplay.Attributes;

namespace CCOCBackend.API.Stacks.Reports;
[Display(Name = "Report")]
public class ReportViewModel : ViewModel
{
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public int Year { get; set; }

    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public ReportType Type { get; set; }
    
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string Description { get; set; }

    [DetailsField(Hidden = true)]
    [JsonIgnore]
    public FileViewModel File { get; set; }

    [Display(Name = "File")]
    [TableColumn(Orderable = ServerClient.Client, Searchable = ServerClient.Client)]
    [DetailsField]
    public string FileDisplay => File.OriginalName;

    public override string ToString()
    {
        return Id;
    }
}