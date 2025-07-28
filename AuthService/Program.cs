
using Microsoft.EntityFrameworkCore;
using AuthService.Domain;
using AuthService.App.Interfaces;
using AuthService.App.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
    
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IAuthorizeService, AuthorizeService>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization(); // Добавляем middleware авторизации

app.MapControllers(); // Маппинг контроллеров

app.Run();