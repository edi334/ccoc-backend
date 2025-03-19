namespace CCOCBackend.API.Api.Dtos;

public class PersonDto
{
    public string Image { get; set; }
    
    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }

    public string Location { get; set; }
    
    public string Type { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<TagDto> Tags { get; set; }
}