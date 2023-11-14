using TPI_Integrador_Prog3.Services.Implementacion;
using TPI_Integrador_Prog3.Services.Interfaces;
using TPI_Integrador_Prog3.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TPI_Integrador_Prog3.Data.Interfaces;
using TPI_Integrador_Prog3.Data.Implemetation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("TpiProgra3ApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Pegar el token generado para loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "TpiProgra3ApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
}); ;

//Cambiar a SQL Server - appsettings.json
builder.Services.AddDbContext<GamesContext>(dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["DB:ConnectionStrings"]).EnableDetailedErrors()
);


#region Repositorys
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
    builder.Services.AddScoped<IClientRepository , ClientRepository>();
    builder.Services.AddScoped<IUserRepository , UserRepository>();
    builder.Services.AddScoped<IGameRepository , GameRepository>();
    builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
    #endregion


    #region Services
    builder.Services.AddScoped<IClientService, ClientService>();
    builder.Services.AddScoped<IAdminService, AdminService>();
    builder.Services.AddScoped<IUserService, UserService>();
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
    });


var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


