using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minimal API", Description = "A simple minimal API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1");
    });
}

app.MapGet("/", () => "Hello World!");

app.Run();
