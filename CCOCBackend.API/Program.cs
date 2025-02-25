using CCOCBackend.API;
using CCOCBackend.API.Data;
using MCMS.Auth;
using MCMS.Base.Helpers;
using MCMS.Base.SwaggerFormly.Models;
using MCMS.Builder;
using MCMS.Common;
using MCMS.Files;

Env.LoadEnvFiles();


var builder = WebApplication.CreateBuilder(args);
var mAppBuilder = new MAppBuilder(builder.Environment);

mAppBuilder = mAppBuilder.AddSpecifications<MCommonSpecifications>()
    .AddSpecifications<MJwtAuthSpecifications>()
    .AddSpecifications<MFilesSpecifications>()
    //.AddSpecifications<MEmailingSpecifications>()
    //.AddSpecifications<MLoggingSpecifications>()
    .AddSpecifications<CCOCBackendSpecifications>()
    .WithPostgres<AppDbContext>()
    .WithSwagger(new SwaggerConfigOptions
    {
        Title = "CCOC Admin",
        Version = "v1",
        UiType = DocsUiType.Both
    },
    new SwaggerConfigOptions
    {
        Title = "CCOC API",
        Version = "v1",
        UiType = DocsUiType.Both
    });

var mApp = mAppBuilder.Build();

mApp.ConfigureServices(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

mApp.Configure(app, app.Services);

app.UseCors("AllowAll");

app.Run();