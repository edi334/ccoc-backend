using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PartnerTypes;
[Authorize(Roles = "Admin")]
public class PartnerTypesAdminApiController : CrudAdminApiController<PartnerTypeEntity, PartnerTypeFormModel, PartnerTypeViewModel>
{
}