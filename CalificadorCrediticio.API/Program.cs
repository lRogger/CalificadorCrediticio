using CalificadorCrediticio.Aplicacion.Usuario;
using CalificadorCrediticio.Dominio;
using CalificadorCrediticio.Dominio.Usuario;
using CalificadorCrediticio.Infraestructura.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyección
/*
    Singleton => cuando lo inyectas siempre te devuelve el mismo objeto(Espacio memoria) - vive hasta que la aplicaicón deja de funcionar
    Scoped => la llamas x veces durante la ejecución de la request te dará el mismo objecto, vive durante la ejecución de request
    Transient =Z cada vez que llamas te crear objeto nueva
 */
builder.Services.AddScoped<IGuardarUsuario, GuardarUsuario>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

