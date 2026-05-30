using Microsoft.EntityFrameworkCore;
using PacificStarBackend;
using PacificStarBackend.Repository;
using PacificStarBackend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Entity Framework
/*builder.Services.AddDbContext<PacificStarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("")));*/

builder.Services.AddScoped<BitacoraService>();

builder.Services.AddDbContext<PacificStarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
