namespace CCOCBackend.API.Api.Dtos;

public class VolunteeringCarouselPageDto
{
    public string Name { get; set; }
    public string Image { get; set; }
}

public class VolunteeringBenefitDto
{
    public string Name { get; set; }
    public string Image { get; set; }
}

public class VolunteeringDto
{
    public string Name { get; set; }
    public string Text { get; set; }
    public string LinkTo { get; set; }
    public IEnumerable<VolunteeringCarouselPageDto> CarouselPages { get; set; }
    public IEnumerable<VolunteeringBenefitDto> Benefits { get; set; }
}