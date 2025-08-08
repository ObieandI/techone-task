var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<NumberToWordsConverter>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapControllers();

app.Run();
