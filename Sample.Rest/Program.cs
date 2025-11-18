using Sample.Application.Students;
using Sample.Application.Students.Contracts;
using Sample.Persistance.EF;
using Sample.Persistance.EF.Students;
using Sample.Rest;

var config = GetEnvironment();

var builder = WebApplication
    .CreateBuilder(new WebApplicationOptions
    {
        EnvironmentName = config.GetValue(
            "environment", defaultValue: "Development"),
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<EFDataContext>(
//     options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<StudentService, StudentAppService>();
builder.Services.AddScoped<StudentRepository, EFStudentRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
static IConfigurationRoot GetEnvironment(
    string settingFileName = "appsettings.json")
{
    var baseDirectory = Directory.GetCurrentDirectory();

    return new ConfigurationBuilder()
        .SetBasePath(baseDirectory)
        .AddJsonFile(settingFileName, optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
}
namespace Sample.Rest
{
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
