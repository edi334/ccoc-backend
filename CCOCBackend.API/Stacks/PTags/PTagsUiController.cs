using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.PTags;
[Authorize(Roles = "Admin")]
[Display(Name = "PTags")]
public class PTagsUiController : GenericModalAdminUiController<PTagEntity, PTagFormModel, PTagViewModel, PTagsAdminApiController>;