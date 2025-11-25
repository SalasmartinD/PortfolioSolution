using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models; // El modelo Project compartido

namespace Portfolio.Api.Data
{
    // Hereda de DbContext
    public class PortfolioDbContext : DbContext
    {
        // El constructor recibe opciones de configuración, incluyendo la cadena de conexión
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {
        }

        // Esta propiedad representa la tabla 'Projects' en la base de datos
        public DbSet<Project> Projects { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Lógica para inicializar la base de datos con los proyectos hardcodeados
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "Sistema de Gestión de Tareas (FocusFlow)",
                    ShortDescription = "Aplicación completa de gestión de tareas con prioridades y notificaciones.",
                    GitHubUrl = "https://github.com/tu-usuario/focus-flow",
                    LiveDemoUrl = "https://focusflow.azurewebsites.net"
                },
                new Project
                {
                    Id = 2,
                    Title = "API de Catálogo de Productos",
                    ShortDescription = "Microservicio para manejar el inventario y catálogo usando NoSQL.",
                    GitHubUrl = "https://github.com/tu-usuario/catalog-api"
                }
            );
        }
    }
}