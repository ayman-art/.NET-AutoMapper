using AutoMapper.Demo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<UserService>();
builder.Services.AddControllers();

// Fix for CS1503: Use a lambda to configure AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
});

var app = builder.Build();

// Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
    });
}

app.MapControllers();
app.Run();
