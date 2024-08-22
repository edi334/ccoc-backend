using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.CarouselPages;
[Authorize(Roles = "Admin")]
public class CarouselPagesAdminApiController : CrudAdminApiController<CarouselPageEntity, CarouselPageFormModel, CarouselPageViewModel>
{
}