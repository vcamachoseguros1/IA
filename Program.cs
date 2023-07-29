using API.Data;
using API.Service;
using Microsoft.EntityFrameworkCore;

// Crear un generador de aplicaciones web (WebApplicationBuilder) usando los argumentos de línea de comandos (args)
var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de controladores al contenedor de servicios
builder.Services.AddControllers();

// Agregar el servicio de API Explorer de endpoints al contenedor de servicios
builder.Services.AddEndpointsApiExplorer();

// Agregar el servicio de generación de Swagger al contenedor de servicios
builder.Services.AddSwaggerGen();

// Configurar el contexto de la base de datos usando una cadena de conexión llamada "StoreConnection" especificada en la configuración (appsettings.json)
builder.Services.AddDbContext<StoreDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Registrar la clase ProductService como una implementación del servicio IProductService en el contenedor de servicios
builder.Services.AddTransient<IProductService, ProductService>();

// Construir la aplicación (WebApplication) a partir del generador
var app = builder.Build();

// Si la aplicación está en el entorno de desarrollo, habilitar Swagger y SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agregar middleware para redireccionar peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Agregar middleware para la autorización
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();