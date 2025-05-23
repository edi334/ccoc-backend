namespace CCOCBackend.API.Api.Dtos;

public class PageDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string Slug { get; set; }
    public IEnumerable<string> Images { get; set; }
}