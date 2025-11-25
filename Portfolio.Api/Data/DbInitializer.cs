// 📄 Portfolio.Api/Data/DbInitializer.cs

using Portfolio.Shared.Models;

namespace Portfolio.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PortfolioDbContext context)
        {
            //Verifica si ya existen proyectos
            if (context.Projects.Any())
            {
                return; // Si hay datos, no hace nada y sale.
            }

            // 2. Define tus tres proyectos
            var projects = new Project[]
            {
                new Project 
                { 
                    Title = "Sistema de Gestión de Tareas (FocusFlow)", 
                    ShortDescription = "Aplicación Web Full-Stack para la gestión de proyectos y tareas con autenticación JWT.", 
                    GitHubUrl = "https://github.com/tu_usuario/focusflow-repo",
                    LiveDemoUrl = "https://demo.focusflow.com",
                    Technologies = string.Join(", ", new List<string> { "ASP.NET Core", "Entity Framework", "Angular/React", "SQL Server" })
                },
                new Project 
                { 
                    Title = "API de Catálogo de Productos", 
                    ShortDescription = "Microservicio RESTful para manejo de inventario y productos. Desarrollado con el patrón Repository.", 
                    GitHubUrl = "https://github.com/tu_usuario/catalogo-api",
                    LiveDemoUrl = "",
                    Technologies = string.Join(", ", new List<string> { ".NET Core", "MongoDB", "Docker", "xUnit" })                },
                new Project 
                { 
                    Title = "Portafolio Personal (Este Sitio)", 
                    ShortDescription = "Sitio web de portafolio moderno y responsivo, demostrando dominio de Blazor WebAssembly y comunicación con API.", 
                    GitHubUrl = "https://github.com/tu_usuario/portfolio-blazor",
                    LiveDemoUrl = "",
                    Technologies = string.Join(", ", new List<string> { "Blazor WebAssembly", "ASP.NET Web API", "SQL Server", "Bootstrap" })                }
            };

            // 3. Agrega los proyectos al contexto y guarda los cambios
            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}