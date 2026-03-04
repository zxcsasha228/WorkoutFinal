using Microsoft.EntityFrameworkCore;
using WorkoutApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Явно указываем порт 5000
builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

// Создаем базу данных если её нет
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();