﻿using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using VacationHireInc.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacation Hire Inc. API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("swagger/v1/swagger.json", "Vacation Hire Inc. API V1");
    options.RoutePrefix = string.Empty;
});

// Use the custom global exception handler middleware
app.UseCustomExceptionHandler();

app.Run();

