using FinancialTamkeenApi.Data;
using FinancialTamkeenApi.Services.Implementation;
using FinancialTamkeenApi.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FinancialDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialConnection"));
});
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title ="Financial Tamkeen",
        Description ="This is Exam ",
        Version = "v1",
        Contact=new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name="Amany Mohammed Saleh Dehaq",
            Email="Amanydaha7719@gmail.com"
        }

        
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapControllers();

app.Run();
