using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Services;
[Authorize(Roles = "Admin")]
[Display(Name = "Services")]
public class ServicesUiController : GenericModalAdminUiController<ServiceEntity, ServiceFormModel, ServiceViewModel, ServicesAdminApiController>
{
}