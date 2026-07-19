using ClubLectura.Infrastructure.Context;
using ClubLectura.Infrastructure.Core;
using ClubLectura.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ClubLecturaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"];
    cfg.AddProfile<MappingProfile>();
});


builder.Services.AddScoped<LibroRepository>();
builder.Services.AddScoped<MiembroRepository>();
builder.Services.AddScoped<ReunionRepository>();
builder.Services.AddScoped<ComentarioRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Solo redirige a HTTPS fuera de desarrollo (evita el "Failed to fetch" en Swagger por http)
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
