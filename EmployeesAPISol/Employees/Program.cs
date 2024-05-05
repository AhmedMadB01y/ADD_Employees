using Employees.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var EmployeesConnectionString = builder.Configuration.GetConnectionString("EmployeesConnection");
// Add services to the container.

builder.Services.AddDbContext<EmployeesDbContext>(options => options.UseSqlServer(EmployeesConnectionString));
builder.Services.AddControllers();
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var employeesContext = services.GetRequiredService<EmployeesDbContext>();
    employeesContext.Database.EnsureCreated();
    EmployeesInitializer.Initialize(employeesContext);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
