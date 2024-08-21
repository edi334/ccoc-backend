using CCOCBackend.API;
using CCOCBackend.API.Data;
using MCMS.Base.Helpers;
using MCMS.Base.SwaggerFormly.Models;
using MCMS.Builder;
using MCMS.Common;

Env.LoadEnvFiles();


var builder = WebApplication.CreateBuilder(args);
var mAppBuilder = new MAppBuilder(builder.Environment);

mAppBuilder = mAppBuilder.AddSpecifications<MCommonSpecifications>()
    //.AddSpecifications<MEmailingSpecifications>()
    //.AddSpecifications<MLoggingSpecifications>()
    .AddSpecifications<CCOCBackendSpecifications>()
    .WithPostgres<AppDbContext>()
    .WithSwagger(new SwaggerConfigOptions
    {
        Title = "CCOC Backend",
        Version = "v1",
        UiType = DocsUiType.Both
    });

var mApp = mAppBuilder.Build();

mApp.ConfigureServices(builder.Services);

var app = builder.Build();

mApp.Configure(app, app.Services);

app.Run();