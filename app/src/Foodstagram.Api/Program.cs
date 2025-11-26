using Foodstagram.Api.Config;
using Foodstagram.Api.DI;
using Foodstagram.Api.Filters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// MVC + Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<GlobalExceptionFilter>();
})
.ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// configs (CORS/Swagger/Auth)
builder.Services.AddApiConfigs(builder.Configuration);

// app services (MediatR/AutoMapper/DbContext/Repos)
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseApiCors();

app.UseHttpsRedirection();

// AuthZ/AuthN
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
