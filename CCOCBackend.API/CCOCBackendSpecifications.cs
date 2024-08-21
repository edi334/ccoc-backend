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
            Name = "Admin",
            Id = "admin",
            IsCollapsable = true,
            Items =
            {
                new MenuLink("Users", typeof(AdminUsersUiController)).WithIconClasses("fas fa-users"),
            }
        });
    }
    
    
}