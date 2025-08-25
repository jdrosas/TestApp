using Microsoft.EntityFrameworkCore;
using System.Text;
using TestApp.Data;
using TestApp.Mappings;
using TestApp.Repository;
using TestApp.Repository.IRepository;
using TestApp.Security.Resources;
using TestApp.Services;
using TestApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? encodedConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(encodedConnection))
{
    throw new InvalidOperationException("No se encontró la cadena de conexión.");
}

byte[] data = Convert.FromBase64String(encodedConnection);
string decodedConnection = Encoding.UTF8.GetString(data);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(decodedConnection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

// Repositories
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

builder.Services.AddHttpClient<IFactService, FactService>(client =>
{
    client.BaseAddress = new Uri("https://catfact.ninja/");
});
builder.Services.AddHttpClient<IGifService, GifService>(client =>
{
    client.BaseAddress = new Uri("https://api.giphy.com/v1/gifs/");
});

//Configurations
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings")
);

// Automapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
