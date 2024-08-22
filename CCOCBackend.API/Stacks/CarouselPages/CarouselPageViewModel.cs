using MCMS.Base.Attributes.JsonConverters;
using MCMS.Base.Data.ViewModels;
using MCMS.Files.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CCOCBackend.API.Stacks.CarouselPages;
[Display(Name = "CarouselPage")]
public class CarouselPageViewModel : ViewModel
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public FileViewModel Image { get; set; }

    public string Name { get; set; }

    public bool Enabled { get; set; }

    public override string ToString()
    {
        return Id;
    }
}