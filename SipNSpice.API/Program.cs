using Microsoft.EntityFrameworkCore;
using SipNSpice.API.Data;
using SipNSpice.API.Repositories.Implementation;
using SipNSpice.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the dbcontext class using dependency injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //linking to the connection string
    options.UseSqlServer(builder.Configuration.GetConnectionString("SipNSpiceConnectionString"));
});

//Injecting the Repositories (Dependency Injection)
builder.Services.AddScoped<ICuisineRepository, CuisineRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Implementation of Cors
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
