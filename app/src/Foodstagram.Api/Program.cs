// src/Foodstagram.Api/Program.cs
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
    // 自動 400 を OFF にして、自前の ValidationFilter で返す
    options.SuppressModelStateInvalidFilter = true;
});

// Swagger / CORS / Auth / DI 拡張
builder.Services.AddApiConfigs(builder.Configuration);
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

// swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseApiCors();

app.UseHttpsRedirection();

// 認証・認可（将来 JWT を入れる前提）
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
