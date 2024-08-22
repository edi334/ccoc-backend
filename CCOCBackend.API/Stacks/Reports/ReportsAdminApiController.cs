using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Reports;
[Authorize(Roles = "Admin")]
public class ReportsAdminApiController : CrudAdminApiController<ReportEntity, ReportFormModel, ReportViewModel>
{
}