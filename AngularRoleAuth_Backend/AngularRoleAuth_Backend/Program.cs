using AngularRoleAuth_Backend.Service.DataBase;
using AngularRoleAuth_Backend.Service.Token;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDataBaseService, DataBaseService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

// Bearer
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(config =>
    {
#pragma warning disable CS8604 // Possible null reference argument.
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["JwtIssuer"],
            ValidAudience = builder.Configuration["JwtIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
        };
#pragma warning restore CS8604 // Possible null reference argument.
    });

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();