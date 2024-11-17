using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MVC.services;
using MVC.settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


//permite utilizar o .env no app
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
EnviromentConfig.Load(dotenv);


//Estabelecendo authentication default e uso de JWT default tb.
var key = Encoding.ASCII.GetBytes(JWTConfig.secret);
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
}); ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

  
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

//Injetando no app o serviço de autenticação
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
 

app.Run();
