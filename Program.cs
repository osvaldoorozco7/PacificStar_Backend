using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Data;
using PacificStarBackend.Repository;
using PacificStarBackend.Repository.Interfaces;
using PacificStarBackend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<PacificStarDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PacificStarDB")
    ));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173",
            "https://pacificstar-services.netlify.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Dependency Injection
builder.Services.AddScoped<IBitacoraRepository, BitacoraRepository>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();
builder.Services.AddScoped<IUnidadRepository, UnidadRepository>();
builder.Services.AddScoped<IUnidadService, UnidadService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Habilita CORS
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();