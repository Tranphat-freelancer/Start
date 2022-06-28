using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Ms.AppTTQH.Web.Menus;
using Ms.Shared.Localization;
using QuanHuyenModule;
using StackExchange.Redis;
using System;
using TinhThanhModule;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Http.Client.Web;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.UI.Navigation.Urls;

namespace Ms.AppTTQH.Web;

[DependsOn(
    typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
    typeof(AbpAspNetCoreMvcClientModule),
    typeof(AbpHttpClientWebModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule),
    typeof(AbpSettingManagementWebModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpIdentityWebModule),
    typeof(AbpTenantManagementWebModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(TinhThanhModuleHttpApiClientModule),
    typeof(QuanHuyenModuleHttpApiClientModule),
    typeof(MsLocalizationModule)
    )]
public class AppTTQHWebModule : AbpModule
{
    //public override void PreConfigureServices(ServiceConfigurationContext context)
    //{
    //    context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
    //    {
    //        options.AddAssemblyResource(
    //            typeof(AppTTQHResource),
    //            typeof(AppTTQHWebModule).Assembly
    //        );
    //    });
    //}

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureBundles();
        ConfigureCache();
        ConfigureDataProtection(context, configuration, hostingEnvironment);
        ConfigureUrls(configuration);
        ConfigureAuthentication(context, configuration);
        ConfigureAutoMapper();
        //ConfigureVirtualFileSystem(hostingEnvironment);
        ConfigureNavigationServices(configuration);
        //ConfigureMultiTenancy();
        //ConfigureSwaggerServices(context.Services);
    }

    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                BasicThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                }
            );
        });
    }

    private void ConfigureCache()
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "AppTTQH:";
        });
    }

    private void ConfigureUrls(IConfiguration configuration)
    {
        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        });
    }

    //private void ConfigureMultiTenancy()
    //{
    //    Configure<AbpMultiTenancyOptions>(options =>
    //    {
    //        options.IsEnabled = MultiTenancyConsts.IsEnabled;
    //    });
    //}

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
            })
            .AddAbpOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                options.ClientId = configuration["AuthServer:ClientId"];
                options.ClientSecret = configuration["AuthServer:ClientSecret"];

                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                var apiScopes = configuration.GetSection("ApiScope").Get<string[]>();
                foreach (var item in apiScopes)
                {
                    options.Scope.Add(item);
                }
                options.ClaimActions.MapAbpClaimTypes();
            });
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AppTTQHWebModule>();
        });
    }

    //private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
    //{
    //    if (hostingEnvironment.IsDevelopment())
    //    {
    //        Configure<AbpVirtualFileSystemOptions>(options =>
    //        {
    //            options.FileSets.ReplaceEmbeddedByPhysical<AppTTQHDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ms.AppTTQH.Domain.Shared"));
    //            options.FileSets.ReplaceEmbeddedByPhysical<AppTTQHApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Ms.AppTTQH.Application.Contracts"));
    //            options.FileSets.ReplaceEmbeddedByPhysical<AppTTQHWebModule>(hostingEnvironment.ContentRootPath);
    //        });
    //    }
    //}

    private void ConfigureNavigationServices(IConfiguration configuration)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AppTTQHMenuContributor(configuration));
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new AppTTQHToolbarContributor());
        });
    }

    //private void ConfigureSwaggerServices(IServiceCollection services)
    //{
    //    services.AddAbpSwaggerGen(
    //        options =>
    //        {
    //            options.SwaggerDoc("v1", new OpenApiInfo { Title = "AppTTQH API", Version = "v1" });
    //            options.DocInclusionPredicate((docName, description) => true);
    //            options.CustomSchemaIds(type => type.FullName);
    //        }
    //    );
    //}

    private void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IConfiguration configuration,
        IWebHostEnvironment hostingEnvironment)
    {
        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("AppTTQH");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "AppTTQH-Protection-Keys");
        }
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();

        //if (MultiTenancyConsts.IsEnabled)
        //{
        //    app.UseMultiTenancy();
        //}

        app.UseAuthorization();
        //app.UseAbpSwaggerUI(options =>
        //{
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "AppTTQH API");
        //});
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
