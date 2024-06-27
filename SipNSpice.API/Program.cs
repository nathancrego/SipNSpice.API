using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SipNSpice.API.Data;
using SipNSpice.API.Repositories.Implementation;
using SipNSpice.API.Repositories.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Configure environment-specific settings
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the dbcontext class using dependency injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Linking to the connection string
    var connectionString = builder.Configuration.GetConnectionString("SipNSpiceConnectionString")
                          ?? builder.Configuration["ConnectionStrings:SipNSpiceConnectionString"];
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    // Linking the authdb to the existing db connection string
    var connectionString = builder.Configuration.GetConnectionString("SipNSpiceConnectionString")
                          ?? builder.Configuration["ConnectionStrings:SipNSpiceConnectionString"];
    options.UseSqlServer(connectionString);
});

//Injecting the Repositories (Dependency Injection)
builder.Services.AddScoped<ICuisineRepository, CuisineRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IRecipeImageRepository, RecipeImageRepository>();
builder.Services.AddScoped<IDrinkImageRepository, DrinkImageRepository>();

//Injecting Identity Core
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("SipNSpice")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

//Injecting Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

//Token validation
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            AuthenticationType = "Jwt",
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

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

app.UseAuthentication();

app.UseAuthorization();

//Static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")),
    RequestPath = string.Empty //serve from root
});

// Fallback for Angular client-side routing
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html"); // Ensure all routes are handled by Angular
});

app.MapControllers();

app.Run();
