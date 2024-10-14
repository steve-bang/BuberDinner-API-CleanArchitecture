using BuberDinner.Api;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middlewares;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);


// Add all services
builder.Services
    .AddPresenation() // BuberDinner.Api
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

