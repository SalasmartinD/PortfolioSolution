using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgresSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: false),
                    Technologies = table.Column<string>(type: "text", nullable: false),
                    GitHubUrl = table.Column<string>(type: "text", nullable: false),
                    LiveDemoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "GitHubUrl", "LiveDemoUrl", "ShortDescription", "Technologies", "Title" },
                values: new object[,]
                {
                    { 1, "https://github.com/tu-usuario/focus-flow", "https://focusflow.azurewebsites.net", "Aplicación completa de gestión de tareas con prioridades y notificaciones.", "", "Sistema de Gestión de Tareas (FocusFlow)" },
                    { 2, "https://github.com/tu-usuario/catalog-api", "", "Microservicio para manejar el inventario y catálogo usando NoSQL.", "", "API de Catálogo de Productos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
