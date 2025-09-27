using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TaskManagement.Application;
using TaskManagement.Infrastructure;
using TaskManagement.Presentation.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayerServices(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddCors(builder =>
{
    builder.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// JWT Auth
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Authentication:Key").Value!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskManagementAppDbContext>();
    db.Database.EnsureCreated(); // or db.Database.Migrate();
    DbSeeder.Seed(db);
}


//builder.Services.AddExceptionHandler(options =>
//{
//    options.ExceptionHandlingPath = "/error";
//});
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
