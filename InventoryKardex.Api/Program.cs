using InventoryKardex.Infrastructure.Db;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddOpenApi();
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddControllers();

// CORS (default policy)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseCors(); // <-- usa la policy default

// IMPORTANT: apply CORS to endpoints
app.MapControllers().RequireCors(); // <-- fuerza CORS en controllers

app.Run();
