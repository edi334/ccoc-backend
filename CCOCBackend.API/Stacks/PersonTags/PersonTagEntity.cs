using MCMS.Base.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PTags;

namespace CCOCBackend.API.Stacks.PersonTags;
[Table("PersonTags")]
public class PersonTagEntity : Entity
{
    [ForeignKey("Person")] public string PersonId { get; set; }
    public PersonEntity Person { get; set; }

    [ForeignKey("PTag")] public string PTagId { get; set; }
    public PTagEntity PTag { get; set; }

    public override string ToString()
    {
        return Id;
    }
}