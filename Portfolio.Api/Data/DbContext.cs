using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models; // Usamos el modelo Project compartido

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


        // Opcional pero recomendado: Sobrescribir OnModelCreating para seedear datos iniciales.
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
                    // EF Core no soporta colecciones de tipos primitivos (List<string>) directamente para HasData,
                    // por lo que podrías usar un string separado por comas o un JSON para el seed. 
                    // Para simplificar, omitiremos la lista de tecnologías en el seed data de EF.
                    // (La manejaremos más adelante si es necesario, pero complejiza el seed inicial).
                    // Para el portafolio, es mejor mostrar la lista de proyectos simple.
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
                // ¡Agrega aquí todos tus proyectos de ejemplo!
            );
        }
    }
}