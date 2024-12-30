using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReposSearchAppServer.Interfaces;
using ReposSearchAppServer.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ReposSearchAppServer.AppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register HttpClient for dependency injection
builder.Services.AddHttpClient();
//Inject all needed Services and Interfaces
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IMarkInterface, MarkService>();
builder.Services.AddScoped<ISearchInterface, SearchService>();
builder.Services.AddScoped<IAuthInterface, AuthService>();
//Inject JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],//get Configure from appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });
//Add Cors for client origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:4200")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
