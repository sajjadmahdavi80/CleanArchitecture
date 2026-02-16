
using System.Reflection;
using Infrastructure;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
//using Microsoft.OpenApi.Models;



namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        builder.Services.AddOpenApiConfiguration();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
            options.OAuthUsePkce();
        });

        app.MapControllers();

        app.Run();
    }
}
internal static class OpenApiExtension
{
    public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services)
    {
        return services.AddOpenApi("v1", options =>
         {
             options.AddDocumentTransformer((document, context, cancellationToken) =>
             {
                 // Ensure instances exist
                 document.Components ??= new OpenApiComponents();
                 document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();



                 // Add OAuth2 security scheme (Authorization Code flow only)
                 document.Components.SecuritySchemes.Add("Bearer", new OpenApiSecurityScheme
                 {
                     Type = SecuritySchemeType.Http,
                     Scheme = "bearer",
                     BearerFormat = "JWT",
                     In = ParameterLocation.Header,
                     Name = "Authorization",
                     Description = "Use jwt "
                 });


                 // Apply security requirement globally
                 document.Security = [
                     new OpenApiSecurityRequirement
                     {
                         {
                             new OpenApiSecuritySchemeReference("Bearer"){Reference = new()
                             {
                                 Type= ReferenceType.SecurityScheme,
                                 Id="Bearer"
                             }
                             },
                             []
                         }
                     }
                 ];

                 // Set the host document for all elements
                 // including the security scheme references
                 document.SetReferenceHostDocument();

                 return Task.CompletedTask;
             });
         });
    }

}

