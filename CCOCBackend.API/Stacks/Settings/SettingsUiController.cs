using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Settings;
[Authorize(Roles = "Admin")]
[Display(Name = "Settings")]
public class SettingsUiController : GenericModalAdminUiController<SettingEntity, SettingFormModel, SettingViewModel, SettingsAdminApiController>
{
}