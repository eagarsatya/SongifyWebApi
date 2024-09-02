using Microsoft.EntityFrameworkCore;
using Songify.Entities.Entities;
using SongifyWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GenreServices>();
builder.Services.AddScoped<SongServices>();

builder.Services.AddDbContext<SongifyContext>(options =>
{
    // Build Configuration to read appsettings value.
    // Can use GetSection value also.
    options.UseSqlServer(builder.Configuration.GetConnectionString("SongifyDb"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
