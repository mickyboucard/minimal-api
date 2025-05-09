using Microsoft.OpenApi.Models;
using MinimalApi.Db;

var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minimal API: Pizza store", Description = "A simple minimal API to support a Pizza store", Version = "v1" });
});

var app = builder.Build();

// Register logging middleware
app.UseMiddleware<LoggingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1");
    });
}

// Routes
app.MapGet("/", () => "This is a simple minimal API to support a Pizza store");

app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

app.Run();
