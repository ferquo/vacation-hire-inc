using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using VacationHireInc.API;
using VacationHireInc.API.Middlewares;
using VacationHireInc.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var originsPolicyName = "MY_CORS_POLICY_NAME";

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<VacationHireIncContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add dependencies from the bussiness logic layer
builder.Services.AddVacationHireIncServiceDependencies();

// Add dependencies from the data access layer
builder.Services.AddVacationHireIncDataAccessDependencies();

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacation Hire Inc. API", Version = "v1" });
});

// Allow any origin for CORS
// (wouldn't do this in production, but this is just a demo😎)
builder.Services.AddCors(options =>
{
    options.AddPolicy(originsPolicyName,
    builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
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
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("swagger/v1/swagger.json", "Vacation Hire Inc. API V1");
    options.RoutePrefix = string.Empty;
});

app.UseCors(originsPolicyName);

// Use the custom global exception handler middleware
app.UseCustomExceptionHandler();

app.Run();

