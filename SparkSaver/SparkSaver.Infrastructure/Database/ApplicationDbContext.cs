using Microsoft.EntityFrameworkCore;
using SparkSaver.Domain.Entities;
using SparkSaver.Domain.Interfaces;

namespace SparkSaver.Infrastructure.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Link> Links { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public IQueryable<T> Query<T>() where T : class
    {
        return Set<T>().AsQueryable();
    }

    void IApplicationDbContext.Add<T>(T entity) where T : class
    {
        Set<T>().Add(entity);
    }

    Task<int> IApplicationDbContext.SaveChangesAsync(CancellationToken ct)
    {
        return SaveChangesAsync(ct);
    }

    public void ApplyMigrations()
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
}
