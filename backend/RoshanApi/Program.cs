using RoshanAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using RoshanApi.Services;
using RoshanAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITransactionsService, TransactionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,   
            ValidateIssuerSigningKey = true,    
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Localization
var supportedCultures = new[] { new CultureInfo("ur-PK"), new CultureInfo("en-US") };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("ur-PK")
    .AddSupportedCultures(supportedCultures.Select(c => c.Name).ToArray())
    .AddSupportedUICultures(supportedCultures.Select(c => c.Name).ToArray());

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
//app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());



app.UseCors("AllowLocalhost");

app.UseAuthentication();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    RoshanAPI.Services.SeedData.Initialize(db);
}

app.UseAuthorization();
app.MapControllers();
app.Run();
