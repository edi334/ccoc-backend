namespace CCOCBackend.API.Api.Dtos;

public class ProjectDto
{
    public string Title { get; set; }

    public string Description { get; set; }
    
    public string Type { get; set; }
    
    public string Slug { get; set; }
    
    public string TitleImage { get; set; }
    
    public string PresentationImage { get; set; }
    
    public bool IsParent { get; set; }
    
    public string ExternalUrl { get; set; }
    
    public ProjectDto Parent { get; set; }
}