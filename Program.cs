var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalWeb", policy =>
    {
        policy
            .WithOrigins("http://localhost:5222", "https://localhost:7024")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("LocalWeb");

app.MapGet("/api/health", () => Results.Ok(new
{
    status = "OK",
    service = "TestWebKubernetes.Api",
    checkedAt = DateTimeOffset.UtcNow
}))
.WithName("HealthCheck");

app.MapGet("/api/products", () =>
{
    Product[] products =
    [
        new(1, "Notebook de pruebas", 1250.00m),
        new(2, "Mouse inalambrico", 35.50m),
        new(3, "Teclado mecanico", 89.99m)
    ];

    return Results.Ok(products);
})
.WithName("GetProducts");

app.Run();

record Product(int Id, string Name, decimal Price);
