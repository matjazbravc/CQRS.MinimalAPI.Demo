using CQRS.MinimalAPI.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MinimalAPI.Demo.Data;

public class DataContext : DbContext
{
    public DbSet<Student>? Students { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}