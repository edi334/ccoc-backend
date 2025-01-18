namespace CCOCBackend.API.Api.Dtos;

public class ArticleDto
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string Content { get; set; }
    public DateTime PublishDate { get; set; }
    public string Slug { get; set; }
    public IEnumerable<TagDto> Tags { get; set; }
}