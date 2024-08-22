using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Controllers.Api;
using MCMS.Base.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CCOCBackend.API.Stacks.ArticleTags;
[Authorize(Roles = "Admin")]
public class ArticleTagsAdminApiController : CrudAdminApiController<ArticleTagEntity, ArticleTagFormModel, ArticleTagViewModel>
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        Repo.ChainQueryable(q => q.Include(c => c.Article).Include(c => c.Tag));
    }

    protected override Task OnCreating(ArticleTagEntity e)
    {
        if (e.Article != null)
            e.Article = ServiceProvider.GetRepo<ArticleEntity>().Attach(e.Article);
        if (e.Tag != null)
            e.Tag = ServiceProvider.GetRepo<TagEntity>().Attach(e.Tag);
        return Task.CompletedTask;
    }
}