using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.ArticleTags;
using CCOCBackend.API.Stacks.CarouselPages;
using CCOCBackend.API.Stacks.MenuItems;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.ProjectEditions;
using CCOCBackend.API.Stacks.Projects;
using CCOCBackend.API.Stacks.Reports;
using CCOCBackend.API.Stacks.Services;
using CCOCBackend.API.Stacks.Settings;
using CCOCBackend.API.Stacks.Tags;
using MCMS.Admin.Users;
using MCMS.Base.Builder;
using MCMS.Display.Link;
using MCMS.Display.Menu;
using Microsoft.AspNetCore.Mvc;

namespace CCOCBackend.API;

public class CCOCBackendSpecifications : MSpecifications
{
    public override void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        base.Configure(app, serviceProvider);
    }

    public override void ConfigMvc(MvcOptions options)
    {
        base.ConfigMvc(options);
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<MenuConfig>(ConfigureMenu);
        base.ConfigureServices(services);
    }

    private void ConfigureMenu(MenuConfig config)
    {
        config.Add(new MenuSection
        {
            Name = "Administration",
            Id = "Administration",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Users", typeof(AdminUsersUiController)).WithIconClasses("fas fa-users"),
                new MenuLink("Settings", typeof(SettingsUiController)).WithIconClasses("fas fa-gear"),
                new MenuLink("Menu Items", typeof(MenuItemsUiController)).WithIconClasses("fas fa-bars")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Projects",
            Id = "Projects",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Projects", typeof(ProjectsUiController)).WithIconClasses("fas fa-diagram-project"),
                new MenuLink("Project Editions", typeof(ProjectEditionsUiController)).WithIconClasses("fas fa-grid")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Articles",
            Id = "Articles",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Articles", typeof(ArticlesUiController)).WithIconClasses("fas fa-newspaper"),
                new MenuLink("Tags", typeof(TagsUiController)).WithIconClasses("fas fa-tags"),
                new MenuLink("Article Tags", typeof(ArticleTagsUiController)).WithIconClasses("fas fa-paperclip")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Reports",
            Id = "Reports",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Reports", typeof(ReportsUiController)).WithIconClasses("fas fa-chart-line")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Other website content",
            Id = "Content",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Main Page Carousel", typeof(CarouselPagesUiController)).WithIconClasses("fas fa-gallery-thumbnails"),
                new MenuLink("CCOC Services", typeof(ServicesUiController)).WithIconClasses("fas fa-handshake"),
                new MenuLink("CCOC People", typeof(PeopleUiController)).WithIconClasses("fas fa-people")
            }
        }.RequiresRoles("Admin"));
    }
}