using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Pages;
[Authorize(Roles = "Admin")]
[Display(Name = "Pages")]
public class PagesUiController : GenericModalAdminUiController<PageEntity, PageFormModel, PageViewModel, PagesAdminApiController>
{
}