using AmarisEmployeesAPI.BL.Interfaces;
using AmarisEmployeesAPI.BL.Services;
using AmarisEmployeesAPI.DAL.Interfaces;
using AmarisEmployeesAPI.DAL.Repositories;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod(); 
    });
});

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddHttpClient("EmployeeApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["EmployeeApi:BaseUrl"]);
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("OpenCorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
