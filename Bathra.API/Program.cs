using Bathra.Application.Interfaces;
using Bathra.Infrastructure.Context;
using Bathra.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure database based on environment
if (builder.Environment.IsDevelopment())
{
    // Use SQLite for development
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    // Use SQL Server for production
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStartupService, StartupService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "Bathra API", 
        Version = "v1",
        Description = "API for Bathra startup investment platform",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Bathra Team",
            Email = "contact@bathra.co",
            Url = new Uri("https://bathra.co")
        }
    });
});

// Add health checks
builder.Services.AddHealthChecks();

// Get allowed origins from configuration
var allowedOrigins = builder.Configuration.GetSection("FrontendSettings:AllowedOrigins").Get<string[]>() ?? 
    new[] { "http://localhost:3000", "https://bathra.co" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

// Apply migrations at startup in development mode
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
    }
}

app.Run();
