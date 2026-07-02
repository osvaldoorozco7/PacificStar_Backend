using Microsoft.EntityFrameworkCore;
using PacificStarBackend.Data;
using PacificStarBackend.Repository;
using PacificStarBackend.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// DbContext
builder.Services.AddDbContext<PacificStarDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PacificStarDB")
    ));

// DI
builder.Services.AddScoped<IBitacoraRepository, BitacoraRepository>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();