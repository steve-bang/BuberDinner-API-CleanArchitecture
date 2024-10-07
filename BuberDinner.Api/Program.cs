using BuberDinner.Api.Filters;
using BuberDinner.Api.Middlewares;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

// Add all services
builder.Services
    .AddApplication() // BuberDinner.Application
    .AddInfrastructure(builder.Configuration); // BuberDinner.Infrastructure


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add ErrorHandlingMiddleware
//app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();


app.Run();

