using System.Globalization;
using System.Text;
using api.Data;
using api.Services;
using api.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "E-COMMERCE FULL HOUSE", 
        Description = "The Full House Commerce API is a RESTful API that allows you to manage the Full House Commerce app's products, brands, customers, products, suppliers, purchases, regions, reviews, sales, and login.", 
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Full House",
            Url = new Uri("https://test-pet-paradise-store.vercel.app/")
        },
        License = new OpenApiLicense
        {
            Name = "About us",
            Url = new Uri("https://test-pet-paradise-store.vercel.app/about")
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers(options =>
{
   options.Conventions.Add(new LowercaseControllerModelConvention());
});

//Service DbContext
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<DataContext>(
    options => options.UseNpgsql(connectionString));

//Service Layer
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<ProviderService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddSingleton(builder.Configuration);
//Injecting an authentication service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"]
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public class LowercaseControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        controller.ControllerName = controller.ControllerName.ToLower();
        foreach (var selectorModel in controller.Selectors)
        {
            selectorModel.AttributeRouteModel.Template = selectorModel.AttributeRouteModel.Template.ToLower();
        }
    }
}


