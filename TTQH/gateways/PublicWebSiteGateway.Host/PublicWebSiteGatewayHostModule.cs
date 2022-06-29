using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ms.Shared.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using QuanHuyenModule;
using StackExchange.Redis;
using System;
using TinhThanhModule;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace PublicWebSiteGateway.Host
{
    [DependsOn(
        //typeof(AbpAutofacModule),
        typeof(TinhThanhModuleHttpApiModule),
        typeof(QuanHuyenModuleHttpApiModule),
        //typeof(AbpEntityFrameworkCoreSqlServerModule),
        //typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        //typeof(AbpSettingManagementEntityFrameworkCoreModule),
        //typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(MsHostingModule),
        typeof(TinhThanhModuleHttpApiClientModule),
        typeof(QuanHuyenModuleHttpApiClientModule)
)]
    public class PublicWebSiteGatewayHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            //Configure<AbpMultiTenancyOptions>(options =>
            //{
            //    options.IsEnabled = MsDemoConsts.IsMultiTenancyEnabled;
            //});

            context.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.Audience = configuration["AuthServer:ClientId"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PublicWebSite Gateway API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });

            context.Services.AddOcelot(context.Services.GetConfiguration());

            //Configure<AbpDbContextOptions>(options =>
            //{
            //    options.UseSqlServer();
            //});

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "MsDemo-DataProtection-Keys");
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            //app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAbpClaimsMap();
            //if (MsDemoConsts.IsMultiTenancyEnabled)
            //{
            //    app.UseMultiTenancy();
            //}
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicWebSite Gateway API");
            });
            app.UseRewriter(new RewriteOptions()
           // Regex for "", "/" and "" (whitespace)
           .AddRedirect("^(|\\|\\s+)$", "/swagger"));
            app.MapWhen(
                ctx => ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/Abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/app/"),
                app2 =>
                {
                    app2.UseRouting();
                    app2.UseConfiguredEndpoints();
                }

            );

            app.UseOcelot().Wait();
        }
    }
}
