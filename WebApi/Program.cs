using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using NLog.Web;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IStrongPasswordService, StrongPasswordService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<StoreDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Home")), ServiceLifetime.Transient);
builder.Host.UseNLog();

var app = builder.Build();
app.Logger.LogInformation("");
app.UseStaticFiles();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
