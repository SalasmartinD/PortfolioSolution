using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveDemoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { 1, "https://github.com/tu-usuario/focus-flow", "https://focusflow.azurewebsites.net", "Aplicación completa de gestión de tareas con prioridades y notificaciones.", "[]", "Sistema de Gestión de Tareas (FocusFlow)" },
                    { 2, "https://github.com/tu-usuario/catalog-api", "", "Microservicio para manejar el inventario y catálogo usando NoSQL.", "[]", "API de Catálogo de Productos" }
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
