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

// --- 1. LÓGICA DE CONEXIÓN A BASE DE DATOS (RENDER vs LOCAL) ---
// Obtener la cadena por defecto (para desarrollo local en tu PC)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Intentar obtener la variable automática que Render crea
var renderDbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

// Si existe la variable de Render, la procesamos para reemplazar la local
if (!string.IsNullOrEmpty(renderDbUrl))
{
    // Render nos da: postgres://user:password@host:port/database
    // Npgsql necesita: Host=...;Database=...;Username=...;Password=...
    try 
    {
        var databaseUri = new Uri(renderDbUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        connectionString = $"Host={databaseUri.Host};" +
                           $"Port={databaseUri.Port};" +
                           $"Database={databaseUri.LocalPath.TrimStart('/')};" +
                           $"Username={userInfo[0]};" +
                           $"Password={userInfo[1]};" +
                           "SSL Mode=Require;Trust Server Certificate=true";
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error parseando DATABASE_URL: {ex.Message}");
    }
}

// Configuración de EF Core con la cadena final
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(
        connectionString,
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