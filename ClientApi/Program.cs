using Microsoft.AspNet.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Create and start the SignalR connection
var connection = new HubConnection("https://localhost/Quest.API/signalr");
var hubProxy = connection.CreateHubProxy("QuestSignalHub");

hubProxy.On<string>("addNewMessageToPage", (message) =>
{
    // Handle messages from the hub here
    var aa = message as string;
});

connection.Closed += () =>
{
    var aa = 's';
};

connection.Error += (error) =>
{
    var aa = error.Message;
};


await connection.Start();



app.UseHttpsRedirection();


app.MapGet("/test", async (HttpContext context) =>
{
    hubProxy.Invoke("Send", "a", "msg").Wait();
    return 2;

}).WithName("test");

app.MapGet("/weathertest", async (HttpContext context) =>
{
    return 1;
})
.WithName("weathertest");

app.MapGet("/weatherforecast3", async (HttpContext context) =>
{
    return 1;
})
.WithName("GetWeatherForecast3");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast2", () =>
{
var forecast = Enumerable.Range(1, 5).Select(index =>
    new WeatherForecast
    (
        DateTime.Now.AddDays(index),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
    ))
    .ToArray();
return forecast;
})
.WithName("GetWeatherForecast");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
