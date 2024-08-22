using System.ComponentModel.DataAnnotations;
using MCMS.Controllers.Ui;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.ArticleTags;
[Authorize(Roles = "Admin")]
[Display(Name = "ArticleTags")]
public class ArticleTagsUiController : GenericModalAdminUiController<ArticleTagEntity, ArticleTagFormModel, ArticleTagViewModel, ArticleTagsAdminApiController>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Article).Include(c => c.Tag));
    }
}