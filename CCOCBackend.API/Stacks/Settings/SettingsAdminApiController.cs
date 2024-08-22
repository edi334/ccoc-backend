using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Settings;
[Authorize(Roles = "Admin")]
public class SettingsAdminApiController : CrudAdminApiController<SettingEntity, SettingFormModel, SettingViewModel>
{
}