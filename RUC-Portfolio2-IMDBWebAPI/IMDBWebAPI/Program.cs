using Application.Interfaces.v1.Repositories;
using Application.Services.v1.AuthService.Command;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using IMDB.Application.Requests;
using IMDB.Application.Services.v1.NameService;
using IMDB.Application.Services.v1.UsersService;
using IMDB.Application.Services.v1.UsersService.Command;
using IMDB.Infrastructure.Repositories.v1.AuthService;
using IMDB.Infrastructure.Utils;
using Infrastructure.Context;
using Infrastructure.Repositories.v1.AuthService;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMDB_API", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

    c.AddSecurityRequirement(securityRequirement);

});

//MEDIATR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//DB CONNECTION
builder.Services.AddDbContext<imdbContext>(ctx => ctx.UseNpgsql(builder.Configuration.GetConnectionString("Development")));

//REGISTER REPOSITORIES
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<INamesRepository, NamesRepository>();

//REGISTER HANDLERS
builder.Services.AddScoped<IRequestHandler<AuthenticateCommand, ResponseMessage>, AuthenticateCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, ResponseMessage>, CreateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateNameCommand, ResponseMessage>, CreateNameCommandHandler>();

//JWT
var tokenKey = builder.Configuration.GetValue<string>("JWTKey");
var key = Encoding.ASCII.GetBytes(tokenKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey));

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
