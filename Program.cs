//program.cs
using aspnet.Contexts;
using aspnet.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// // Correctly bind to all network interfaces
builder.WebHost.UseUrls("http://*:5152");

//Add services to the container.
builder.Services.AddControllers();//add controller classes to be used

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepo, MySQLRepo>();

String _connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<BookContext>(option => option.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

// activating the automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();  //redirect to https
app.UseAuthorization(); //allow [ attribute in controller
app.MapControllers();   //map all controller classes
app.Run();  //start API
