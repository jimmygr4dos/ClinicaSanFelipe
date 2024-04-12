using AutoMapper;
using ClinicaSanFelipe.Core.Exceptions;
using ClinicaSanFelipe.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddOptions(builder.Configuration);
builder.Services.AddDBContexts(builder.Configuration);
builder.Services.AddServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
});

var app = builder.Build();

app.UseExceptionHandler(options =>
{
    options.Run(
        async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                if (ex.Error.GetType() == typeof(BusinessException))
                {
                    var exception = (BusinessException)ex.Error;
                    var validation = new
                    {
                        Status = 400,
                        Title = "Bad Request",
                        Detail = exception.Message
                    };
                    var json = new
                    {
                        errors = new[] { validation }
                    };
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(json);
                }
                else
                {
                    await context.Response.WriteAsJsonAsync(ex.Error.Message);
                }
            }
        }
    );
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
