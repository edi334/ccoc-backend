using MCMS.Base.Data.Entities;
using MCMS.Files.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCOCBackend.API.Stacks.People;
[Table("People")]
public class PersonEntity : Entity
{
    public FileEntity Image { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Location { get; set; }
    
    public PersonType Type { get; set; }
    
    public string Description { get; set; }
    
    public override string ToString()
    {
        return Id;
    }
}