using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Server.DataAcess;
using TicketManagmentSystem.Server.DataAcess.Interceptors;
using TicketManagmentSystem.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSingleton<AuditFieldsInterceptor>();
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddInterceptors(sp.GetRequiredService<AuditFieldsInterceptor>()));
var app = builder.Build();


app.UseMiddleware<GlobalErrorHandler>();
app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
