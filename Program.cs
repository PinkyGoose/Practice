using Practice.Data;
using Practice.Models;
using Microsoft.EntityFrameworkCore;
using Practice.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookDb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AtheneumDb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();



var app = builder.Build();
//... rest of the code omitted for brevity



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BookController}/{action=books}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AtheneumController}/{action=atheneums}");


app.Run();


