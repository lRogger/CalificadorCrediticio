using System.Text;
using CalificadorCrediticio.API.Controllers.v1.Autenticacion;
using CalificadorCrediticio.Aplicacion.Autenticacion;
using CalificadorCrediticio.Aplicacion.Usuario;
using CalificadorCrediticio.Dominio;
using CalificadorCrediticio.Dominio.Helper;
using CalificadorCrediticio.Dominio.Usuario;
using CalificadorCrediticio.Infraestructura.Seguridad;
using CalificadorCrediticio.Infraestructura.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<IGenerarToken, GenerarToken>();
builder.Services.AddScoped<ValidarCredenciales>();
builder.Services.AddScoped<GenerardorToken>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Seguridad:issuer"],
        ValidAudience = builder.Configuration["Seguridad:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Seguridad:key"]))
    };
});

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

