using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.Reports;
[Table("Reports")]
public class ReportEntity : Entity
{
    public string Description { get; set; }

    public int Year { get; set; }

    public ReportType Type { get; set; }

    public FileEntity File { get; set; }

    public override string ToString()
    {
        return Id;
    }
}