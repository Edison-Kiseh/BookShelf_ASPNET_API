//program.cs
using aspnet.Contexts;
using aspnet.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();  //redirect to https
app.UseAuthorization(); //allow [ attribute in controller
app.MapControllers();   //map all controller classes
app.Run();  //start API

// public class MainProgram
// {
//     public static void Main(string[] args)
//         => CreateHostBuilder(args).Build().Run();

//     // EF Core uses this method at design time to access the DbContext
//     public static IHostBuilder CreateHostBuilder(string[] args)
//         => Host.CreateDefaultBuilder(args)
//             .ConfigureWebHostDefaults(
//                 webBuilder => webBuilder.UseStartup<Startup>());
// }

// public class Startup
// {
//     public void ConfigureServices(IServiceCollection services)
//         => services.AddDbContext<ApplicationDbContext>();

//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//     }
// }

// public class ApplicationDbContext : DbContext
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//         : base(options)
//     {
//     }
// }