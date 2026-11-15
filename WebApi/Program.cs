using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IStrongPasswordService, StrongPasswordService>();
//Question: GetConnectionString looks up a setting name in appsettings.json, but here it gets the connection string itself: where should the connection string be kept?
builder.Services.AddDbContext<StoreDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Data Source=DESKTOP-JC2M436;Initial Catalog=StoreDB;Integrated Security=True;Trust Server Certificate=True")), ServiceLifetime.Transient);
var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
