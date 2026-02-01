namespace SparkSaver.Domain.Interfaces;

public interface IApplicationDbContext
{
    public IQueryable<T> Query<T>() where T : class;

    public void Add<T>(T entity) where T : class;

    public Task<int> SaveChangesAsync(CancellationToken ct);

    public void ApplyMigrations();
}
