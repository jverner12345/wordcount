using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WordCount.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WordCount.Api", 
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "jverner75@gmail.com",
                        Url = new Uri("https://github.com/jverner12345"),
                        Name = "Jamie Verner"
                    },
                    Description = "Api allowing users to count the occurence of words in a sentence."
                });

                // include API xml documentation
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                   $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
        }
        
        private static string GetXmlDocumentationFileFor(Assembly assembly)
        {
            var documentationFile = $"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)}.xml";
            var path = Path.Combine(AppContext.BaseDirectory, documentationFile);

            return path;
        }
    }
}