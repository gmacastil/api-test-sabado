using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Obtener la variable de entorno
string? citySummary = Environment.GetEnvironmentVariable("VEHICULOS");
int min = int.Parse(Environment.GetEnvironmentVariable("MIN"));
int max = int.Parse(Environment.GetEnvironmentVariable("MAX"));

// Lista de summaries por defecto
var summaries = new[] {"" };

// Si la variable de entorno está definida, separar los valores por comas y asignarlos a summaries
if (!string.IsNullOrEmpty(citySummary))
{
    summaries = citySummary.Split(',');
}

app.MapGet("/ciudades", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(min, max),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetCiudades")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
