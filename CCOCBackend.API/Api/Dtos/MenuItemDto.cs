namespace CCOCBackend.API.Api.Dtos;

public class MenuItemDto
{
    public string Name { get; set; }

    public string Link { get; set; }
    
    public IEnumerable<MenuItemDto>? Children { get; set; }
}