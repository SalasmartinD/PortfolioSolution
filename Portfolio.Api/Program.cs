using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data; // Para usar DbInitializer y DbContext
using Swashbuckle.AspNetCore.SwaggerGen; // Necesario para Swagger/OpenAPI
using Portfolio.Api.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- REGISTRO DE SERVICIOS (builder.Services) ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmailService, EmailService>();

// CONFIGURACIÓN DE ENTITY FRAMEWORK CORE
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql( 
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery) // Práctica de rendimiento recomendada
    )
);
// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowBlazorClient", // Nombre de la política
                      policy =>
                      {
                          policy.AllowAnyOrigin() // Permite cualquier URL (incluyendo Blazor)
                                .AllowAnyHeader()  // Permite el encabezado Content-Type (necesario para JSON)
                                .AllowAnyMethod(); // Permite GET, POST, etc. (necesario para POST)
                      });
});

var app = builder.Build();

// --- LÓGICA DE INICIALIZACIÓN DE DATOS (SEEDING) ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PortfolioDbContext>();
        // Ejecuta el Seeder
        DbInitializer.Initialize(context); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al inicializar la base de datos.");
    }
}
// --------------------------------------------------

// --- CONFIGURACIÓN DEL PIPELINE HTTP (app.Use...) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorClient"); // Aplicar CORS
app.UseAuthorization();

app.MapControllers(); // Habilitar controladores

app.Run();