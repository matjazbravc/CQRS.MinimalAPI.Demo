using System.Reflection;
using CQRS.MinimalAPI.Demo.Data;
using CQRS.MinimalAPI.Demo.Endpoints.Students.Create;
using CQRS.MinimalAPI.Demo.Endpoints.Students.Delete;
using CQRS.MinimalAPI.Demo.Endpoints.Students.GetAll;
using CQRS.MinimalAPI.Demo.Endpoints.Students.GetById;
using CQRS.MinimalAPI.Demo.Endpoints.Students.GetByName;
using CQRS.MinimalAPI.Demo.Endpoints.Students.Update;
using CQRS.MinimalAPI.Demo.Services;
using CQRS.MinimalAPI.Demo.Services.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers the given context as a service.
builder.Services.AddDbContext<DataContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  options.UseSqlite(connectionString, opt =>
  {
    opt.CommandTimeout((int)TimeSpan.FromSeconds(60).TotalSeconds);
  });
});

// Registers handlers and mediator types from the specified assemblies.
builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddTransient<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IStudentsService, StudentsService>();

WebApplication app = builder.Build();

// Migrate database
using (IServiceScope scope = app.Services.CreateScope())
{
  IServiceProvider services = scope.ServiceProvider;
  DataContext context = services.GetRequiredService<DataContext>();
  await context.Database.MigrateAsync();
  DataSeeder.Seed(context);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapGetAllStudents()
  .MapGetByIdStudent()
  .MapGetByNameStudent()
  .MapPostCreateStudent()
  .MapPutUpdateStudent()
  .MapDeleteStudent();

// Redirection to Swagger UI
app.MapGet("", context =>
{
  context.Response.Redirect("./swagger/index.html", permanent: false);
  return Task.CompletedTask;
});

await app.RunAsync();