using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Deployment;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Recipes.RecipeSteps;
using OrchardCore.Recipes.Services;

namespace OrchardCore.Recipes
{
    /// <summary>
    /// These services are registered on the tenant service collection
    /// </summary>
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddRecipes();

            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddRecipeExecutionStep<CommandStep>();
            services.AddRecipeExecutionStep<RecipesStep>();

            services.AddDeploymentTargetHandler<RecipeDeploymentTargetHandler>();
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaRoute(
                name: "Recipes",
                areaName: "OrchardCore.Recipes",
                template: "Admin/OrchardCore.Recipes/Admin/Index",
                defaults: new { controller = "Admin", action = "Index" }
            );
        }
    }
}
