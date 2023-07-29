using API.Data;
using API.Service;
using Microsoft.EntityFrameworkCore;

// Crear un generador de aplicaciones web (WebApplicationBuilder) usando los argumentos de l�nea de comandos (args)
var builder = WebApplication.CreateBuilder(args);

// Agregar el servicio de controladores al contenedor de servicios
builder.Services.AddControllers();

// Agregar el servicio de API Explorer de endpoints al contenedor de servicios
builder.Services.AddEndpointsApiExplorer();

// Agregar el servicio de generaci�n de Swagger al contenedor de servicios
builder.Services.AddSwaggerGen();

// Configurar el contexto de la base de datos usando una cadena de conexi�n llamada "StoreConnection" especificada en la configuraci�n (appsettings.json)
builder.Services.AddDbContext<StoreDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Registrar la clase ProductService como una implementaci�n del servicio IProductService en el contenedor de servicios
builder.Services.AddTransient<IProductService, ProductService>();

// Construir la aplicaci�n (WebApplication) a partir del generador
var app = builder.Build();

// Si la aplicaci�n est� en el entorno de desarrollo, habilitar Swagger y SwaggerUI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agregar middleware para redireccionar peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Agregar middleware para la autorizaci�n
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();