using Back_End.DAO;
using Back_End.Data.DatabaseContext;
using Back_End.Repositories;
using Back_End.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mon API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

var API_KEY = "MaCleSecrete";

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/swagger"))
    {
        await next();
        return;
    }

    if (!context.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey))
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("API Key is missing.");
        return;
    }

    if (!API_KEY.Equals(extractedApiKey))
    {
        context.Response.StatusCode = 403; // Forbidden
        await context.Response.WriteAsync("Invalid API Key.");
        return;
    }

    await next();
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mon API V1");
    c.RoutePrefix = "swagger";
});

app.MapControllers();

app.Run();
