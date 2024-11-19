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
            Name = "Administrare Site",
            Id = "Administration",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Utilizatori", typeof(AdminUsersUiController)).WithIconClasses("fas fa-users"),
                new MenuLink("Setări", typeof(SettingsUiController)).WithIconClasses("fas fa-gear"),
                new MenuLink("Meniu", typeof(MenuItemsUiController)).WithIconClasses("fas fa-bars")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Proiecte",
            Id = "Projects",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Proiecte", typeof(ProjectsUiController)).WithIconClasses("fas fa-diagram-project"),
                new MenuLink("Ediții", typeof(ProjectEditionsUiController)).WithIconClasses("fas fa-table")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Anunțuri",
            Id = "Articles",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Anunțuri", typeof(ArticlesUiController)).WithIconClasses("fas fa-newspaper"),
                new MenuLink("Categorii", typeof(TagsUiController)).WithIconClasses("fas fa-tags"),
                new MenuLink("Articole-Categorii", typeof(ArticleTagsUiController)).WithIconClasses("fas fa-paperclip")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Rapoarte",
            Id = "Reports",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Rapoarte", typeof(ReportsUiController)).WithIconClasses("fas fa-chart-line")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Alt conținut",
            Id = "Content",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Carusel", typeof(CarouselPagesUiController)).WithIconClasses("fas fa-water"),
                new MenuLink("Servicii", typeof(ServicesUiController)).WithIconClasses("fas fa-handshake"),
                new MenuLink("Oameni", typeof(PeopleUiController)).WithIconClasses("fas fa-person")
            }
        }.RequiresRoles("Admin"));
    }
}