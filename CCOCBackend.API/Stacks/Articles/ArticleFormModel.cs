using MCMS.Base.Data.FormModels;
using MCMS.Base.SwaggerFormly.Formly.Fields;
using MCMS.Files.Attributes;
using MCMS.Files.Controllers;
using MCMS.Files.Models;
using System;

namespace CCOCBackend.API.Stacks.Articles;
public class ArticleFormModel : IFormModel
{
    public string Title { get; set; }

    [FormlyFile(typeof(FilesAdminApiController), nameof(FilesAdminApiController.Upload), "unknown-purpose", "default")]
    public FileViewModel Image { get; set; }

    [FormlyCkEditor]
    public string Content { get; set; }

    public DateTime PublishDate { get; set; }
}