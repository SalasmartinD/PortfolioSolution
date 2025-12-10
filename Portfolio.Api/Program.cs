using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Portfolio.Api.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- REGISTRO DE SERVICIOS ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmailService, EmailService>();

// 1. OBTENER LA CADENA DE CONEXIÓN
// Esto leerá automáticamente 'appsettings.json'
// Y leerá automáticamente la variable 'ConnectionStrings__DefaultConnection' en Render
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. CONFIGURAR EF CORE
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(
        connectionString, // Usamos la cadena directa
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
    )
);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowBlazorClient",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
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
        
        // Opcional: Esto asegura que la DB se cree si no existe al desplegar
        // context.Database.Migrate(); 
        
        DbInitializer.Initialize(context); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al inicializar la base de datos.");
    }
}

// --- CONFIGURACIÓN DEL PIPELINE HTTP ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // 2. HTTPS Redirection solo en desarrollo para evitar errores en Docker/Render
    app.UseHttpsRedirection(); 
}

app.UseCors("AllowBlazorClient");
app.UseAuthorization();

app.MapGet("/ping", () => "¡Pong! La API está viva y escuchando.");

app.MapControllers();

app.Run();