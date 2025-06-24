using FirstNetApi.Middlewares;
using Microsoft.OpenApi.Models;
using Restaurants.Application.Extensions;
using Restaurants.Infrastrucutre.Extensions;
using Restaurants.Infrastrucutre.Seeders;
using Resuaurants.Domain.Entities;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
            },
            []
        }
    });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<ExecutedTimeMiddleware>();
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration);

});
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<ExecutedTimeMiddleware>();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
