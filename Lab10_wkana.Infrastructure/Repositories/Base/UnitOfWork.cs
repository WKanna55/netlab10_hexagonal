using System.Collections;
using Lab10_wkana.Domain.Interfaces.Base;
using Lab10_wkana.Infrastructure.Context;

namespace Lab10_wkana.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Hashtable? _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    /*
     * Funcion para usar un repositorio generico con cualquier entidad
     */
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<TEntity>)_repositories[type];
        }

        var repositoryType = typeof(Repository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IRepository<TEntity>)repositoryInstance;
        }
        
        throw new Exception($"No se pudo crear el repositorio para este tipo {type}");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}