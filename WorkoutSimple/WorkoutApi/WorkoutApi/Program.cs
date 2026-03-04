using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WorkoutApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Настройка статических файлов для клиента
app.UseDefaultFiles();
app.UseStaticFiles();

// Обслуживание статических файлов из папки клиента
var clientWwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "WorkoutApp", "wwwroot");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(clientWwwrootPath),
    RequestPath = ""
});

app.MapControllers();
app.MapFallbackToFile("index.html", new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(clientWwwrootPath)
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();