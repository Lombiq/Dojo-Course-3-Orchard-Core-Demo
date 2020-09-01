using DojoCourse.Module.Drivers;
using DojoCourse.Module.Events;
using DojoCourse.Module.Filters;
using DojoCourse.Module.Handlers;
using DojoCourse.Module.Indexes;
using DojoCourse.Module.Migrations;
using DojoCourse.Module.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Users.Events;
using System;
using YesSql.Indexes;

namespace DojoCourse.Module
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddContentPart<PersonPart>()
                .UseDisplayDriver<PersonPartDisplayDriver>()
                .AddHandler<PersonPartHandler>();
            services.AddScoped<IDataMigration, PersonMigrations>();
            services.AddSingleton<IIndexProvider, PersonPartIndexProvider>();

            services.Configure<MvcOptions>(options => options.Filters.Add(typeof(ShapeInjectingFilter)));

            services.AddScoped<ILoginFormEvent, LoginGreeting>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "DojoCourse.Module",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}