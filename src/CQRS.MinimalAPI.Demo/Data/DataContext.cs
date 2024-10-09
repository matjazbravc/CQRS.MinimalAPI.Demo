using CQRS.MinimalAPI.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MinimalAPI.Demo.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
  public DbSet<Student>? Students { get; set; }
}