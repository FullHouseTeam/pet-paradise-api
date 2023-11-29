using api.Data;
using api.Services;
using api.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
