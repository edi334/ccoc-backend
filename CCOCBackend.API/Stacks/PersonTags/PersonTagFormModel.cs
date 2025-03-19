using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PTags;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.PersonTags;
public class PersonTagFormModel : IFormModel
{
    [DisablePatchSubProperties]
    [FormlySelect(typeof(PeopleAdminApiController), labelProp: "email", ShowReloadButton = true)]
    public PersonViewModel Person { get; set; }

    [DisablePatchSubProperties]
    [FormlySelect(typeof(PTagsAdminApiController), labelProp: "name", ShowReloadButton = true)]
    public PTagViewModel PTag { get; set; }
}