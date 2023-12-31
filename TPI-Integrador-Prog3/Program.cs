﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TPI_Integrador_Prog3.Data.Implementations;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using TPI_Integrador_Prog3.Services.Implementations;
using TPI_Integrador_Prog3.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization(options => //Agregamos políticas para la autorización de los respectivos ENDPOINTS.
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("usertype", "Admin"));
    options.AddPolicy("Client", policy => policy.RequireClaim("usertype", "Client"));
    options.AddPolicy("All", policy => policy.RequireClaim("usertype", "Admin", "Client"));
});

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("TPI-Integrador-Prog3BearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http, //utilizando un esquema de seguridad basado en HTTP.
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement //: Este método se utiliza para agregar requisitos de seguridad a Swagger. 
    //2- creando una nueva instancia de OpenApiSecurityRequirement, que representa los requisitos de seguridad para Swagger.


    {
        {
            new OpenApiSecurityScheme //especificando un esquema de seguridad
            {
                Reference = new OpenApiReference //estableciendo una referencia al esquema de seguridad.
                {
                    Type = ReferenceType.SecurityScheme, //Indica que la referencia es de tipo "SecurityScheme", hace referencia a un esquema de seguridad.
                    Id = "TPI-Integrador-Prog3BearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() } //Esta proporcionando una lista vacía de ámbitos (scopes). Este es un lugar donde normalmente
                                        //se especificarían los ámbitos requeridos para acceder a las rutas protegidas.
    });
}); ;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//configura AutoMapper para que el mismo pueda realizar asignaciones automáticas entre objetos. Los perfiles de mapeo se definen
//en las assemblies cargadas en el dominio de la aplicación, lo que permite a AutoMapper descubrir y utilizar esos perfiles durante la ejecución.
//Ademas funciona para que cuando pasemos un DTO, se mapeen sus datos correctamente en la Base de Datos de su respectiva ENTITY.

//Cambiar a SQL Server - appsettings.json
//Hacemos la inyección de dependencia de nuestro contexto para que utilice X base de datos.
//Arrow function para indicar que las "options" sean del tipo de la base de datos que queremos manejar
builder.Services.AddDbContext<GamesContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["DB:ConnectionStrings"]).EnableDetailedErrors());

#region Injections
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

#endregion

#region Repositories
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticación que tenemos que elegir después en PostMan para pasarle el token
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //redirigir automáticamente las solicitudes HTTP a HTTPS
//Garantiza que las comunicaciones entre el cliente y el servidor web se realicen de manera segura a través de HTTPS en lugar de HTTP,
//lo que cifra la información transmitida y ayuda a proteger la integridad y confidencialidad de los datos.

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();