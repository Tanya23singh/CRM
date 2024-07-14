using CRM_Web_Api.ConnectionFunctions;
using CRM_Web_Api.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Security.Claims;

using System.Security.Cryptography;
using CRM_Web_Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CRM_Web_Api.Services;
using CRM_Web_Api.DAL.DAL_User_Repo;
using CRM_Web_Api.DAL.DAL_Contact_Repo;
using CRM_Web_Api.DAL.DAL_SupportTicket_Repo;
using CRM_Web_Api.DAL.DAL_Sales_repo;
using CRM_Web_Api.DAL.DAL_Opportunity_Repo;
using CRM_Web_Api.DAL.DAL_Lead_Repo;
using CRM_Web_Api.DAL.DAL_Campaign_Repo;
using CRM_Web_Api.DAL.DAL_Account_Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<adofunc>(_ => new adofunc(connectionString));
builder.Services.AddSingleton<login_repo>(_ => new login_repo(connectionString));
builder.Services.AddSingleton<Menu_repo>(_ => new Menu_repo(connectionString));
builder.Services.AddSingleton<DAL_Roles>(_ => new DAL_Roles(connectionString));
builder.Services.AddSingleton<DAL_Contact>(_ => new DAL_Contact(connectionString)); 
builder.Services.AddSingleton<Account>(_ => new Account(connectionString));
builder.Services.AddSingleton<Campaign>(_ => new Campaign(connectionString)); 
builder.Services.AddSingleton<Lead>(_ => new Lead(connectionString));
builder.Services.AddSingleton<Opportunity>(_ => new Opportunity(connectionString));
builder.Services.AddSingleton<Sales>(_ => new Sales(connectionString));
builder.Services.AddSingleton<SupportTicket>(_ => new SupportTicket(connectionString));
builder.Services.AddSingleton<Permissions_repo>(_ => new Permissions_repo(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
            };
    });
var app = builder.Build();


app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
    context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

    if (context.Request.Method == HttpMethods.Options)
    {
        context.Response.StatusCode = StatusCodes.Status200OK;
        return;
    }

    await next();
});

byte[] key = GenerateRandomKey(32); // 256-bit key size
byte[] iv = GenerateRandomIV(16);   // 128-bit block size
static byte[] GenerateRandomKey(int keySizeInBytes)
{
    byte[] keyBytes = new byte[keySizeInBytes];
    using (var rng = new RNGCryptoServiceProvider())
    {
        rng.GetBytes(keyBytes);
    }
    return keyBytes;
}

// Helper method to generate random IV
static byte[] GenerateRandomIV(int blockSizeInBytes)
{
    byte[] ivBytes = new byte[blockSizeInBytes];
    using (var rng = new RNGCryptoServiceProvider())
    {
        rng.GetBytes(ivBytes);
    }
    return ivBytes;
}
// Initialize AdoFunc with configuration values
adofunc.Initialize(key, iv);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Add authentication middleware

app.UseAuthorization();
app.Use(async (context, next) =>
{
    var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

    // Extract the token from the authorization header
    if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
    {
        var token = authorizationHeader.Substring("Bearer ".Length);
        var abc = DecodeJwtToken(token);
        foreach (Claim claim in abc.Claims)
        {
            if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
            {
                Shared_service.userid = claim.Value;
            }
            if (claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
            {
                Shared_service.userrole = claim.Value;
            }

        }
        //Shared_service.userid =;
        //Shared_service.userrole =;
        // Do something with the token...
    }

    await next();
});
app.MapControllers();

app.Run();
  JwtSecurityToken DecodeJwtToken(string jwtToken )
{
    var jwtSettings = builder.Configuration; // Accessing builder.Configuration directly

    var secretKey = jwtSettings["JWT:Secret"];
    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = symmetricSecurityKey,
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true
    };

    try
    {
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out securityToken);
        return securityToken as JwtSecurityToken;
    }
    catch (Exception ex)
    {
        // Token validation failed
        Console.WriteLine($"Token validation failed: {ex.Message}");
        return null;
    }
}