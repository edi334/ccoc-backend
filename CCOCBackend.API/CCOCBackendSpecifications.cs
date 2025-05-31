using CCOCBackend.API.Pages;
using CCOCBackend.API.Stacks.Articles;
using CCOCBackend.API.Stacks.ArticleTags;
using CCOCBackend.API.Stacks.CarouselPages;
using CCOCBackend.API.Stacks.PageImages;
using CCOCBackend.API.Stacks.Partners;
using CCOCBackend.API.Stacks.PartnerTypes;
using CCOCBackend.API.Stacks.People;
using CCOCBackend.API.Stacks.PersonTags;
using CCOCBackend.API.Stacks.Projects;
using CCOCBackend.API.Stacks.PTags;
using CCOCBackend.API.Stacks.Resources;
using CCOCBackend.API.Stacks.Services;
using CCOCBackend.API.Stacks.Settings;
using CCOCBackend.API.Stacks.Shortcuts;
using CCOCBackend.API.Stacks.Tags;
using CCOCBackend.Api.Stacks.VolunteeringBenefits;
using CCOCBackend.API.Stacks.VolunteeringCarouselPages;
using CCOCBackend.API.Stacks.Volunteerings;
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
            Name = "Oameni",
            Id = "People",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Oameni", typeof(PeopleUiController)).WithIconClasses("fas fa-newspaper"),
                new MenuLink("Categorii", typeof(PTagsUiController)).WithIconClasses("fas fa-tags"),
                new MenuLink("Oameni-Categorii", typeof(PersonTagsUiController)).WithIconClasses("fas fa-paperclip")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Resurse",
            Id = "Resources",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Resurse", typeof(ResourcesUiController)).WithIconClasses("fas fa-chart-line")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Parteneri",
            Id = "Partners",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Parteneri", typeof(PartnersUiController)).WithIconClasses("fas fa-handshake"),
                new MenuLink("Tipuri de Parteneri", typeof(PartnerTypesUiController)).WithIconClasses("fas fa-file")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Pagini",
            Id = "Pages",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Pagini", typeof(PagesUiController)).WithIconClasses("fas fa-file"),
                new MenuLink("Imagini", typeof(PageImagesUiController)).WithIconClasses("fas fa-file")
            }
        }.RequiresRoles("Admin"));
        config.Add(new MenuSection
        {
            Name = "Voluntariat",
            Id = "Volunteering",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Voluntariat", typeof(VolunteeringsUiController)).WithIconClasses("fas fa-handshake"),
                new MenuLink("Carusel", typeof(VolunteeringCarouselPagesUiController)).WithIconClasses("fas fa-water"),
                new MenuLink("Beneficii", typeof(VolunteeringBenefitsUiController)).WithIconClasses("fas fa-arrow-up")
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
                new MenuLink("Shortcuts", typeof(ShortcutsUiController)).WithIconClasses("fas fa-link"),
            }
        }.RequiresRoles("Admin"));
    }
}