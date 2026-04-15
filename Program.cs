using MongoDB.Driver;
using Backend_Game._Module.Match_Map_1.Configurations;
using Backend_Game._Module.PlayerModule.Configuration;
using Backend_Game.Shared.Core.Ports;
using Backend_Game.Shared.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddMatchMap1Module();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddPlayerModule();
var configuration = builder.Configuration.GetSection("MongoDbSettings");
var connectionString = configuration["ConnectionString"];
var dbName = configuration["DatabaseName"];
// Đăng ký vào hệ thống DI để các class khác chỉ việc lấy ra xài
// Khởi tạo MongoClient (Cái này nên là Singleton)

var mongoClient = new MongoClient(connectionString);
var mongoDatabase = mongoClient.GetDatabase(dbName);
builder.Services.AddSingleton(mongoClient);
builder.Services.AddSingleton(mongoDatabase);
builder.Services.AddScoped<IDatabase, MongoDBContext>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
//DI route cho module Match_Map_1

app.AddRouteMap1Configurations();
app.Run();
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
