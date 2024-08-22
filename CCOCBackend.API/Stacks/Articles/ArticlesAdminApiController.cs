using MCMS.Controllers.Api;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.Articles;
[Authorize(Roles = "Admin")]
public class ArticlesAdminApiController : CrudAdminApiController<ArticleEntity, ArticleFormModel, ArticleViewModel>
{
}