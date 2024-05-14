using Microsoft.EntityFrameworkCore;
using MusicPortalWebAPIClient.Models;
using MusicPortalWebAPIClient.Repositories;


var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ClassContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connection));
builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Genre>, GenreRepository>();
builder.Services.AddScoped<IRepository<Song>, SongRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
