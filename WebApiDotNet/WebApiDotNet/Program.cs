using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiDotNet.Data;
using WebApiDotNet.Data.Entities;
using WebApiDotNet.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<UserEntity, RoleEntity>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<MyDatabaseContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await app.SeedData();

app.Run();
