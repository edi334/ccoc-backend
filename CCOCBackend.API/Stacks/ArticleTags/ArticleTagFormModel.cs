using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly;
using MCMS.Base.SwaggerFormly.Formly.Fields;

namespace CCOCBackend.API.Stacks.ArticleTags;
public class ArticleTagFormModel : IFormModel
{
    [DisablePatchSubProperties]
    [FormlySelect(typeof(ArticlesAdminApiController), labelProp: "title", ShowReloadButton = true)]
    public ArticleViewModel Article { get; set; }

    [DisablePatchSubProperties]
    [FormlySelect(typeof(TagsAdminApiController), labelProp: "name", ShowReloadButton = true)]
    public TagViewModel Tag { get; set; }
}