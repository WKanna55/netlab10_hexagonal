using Lab10_wkana.Domain.Interfaces.Base;
using Lab10_wkana.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab10_wkana.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : class 
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    
    public virtual async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    
    public virtual async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public virtual Task UpdateAsync(T entity)
    { 
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null) return false;
        _context.Set<T>().Remove(entity);
        return true;
    }
    
    
}