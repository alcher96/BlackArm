using System.Data.Entity;
using System.Linq.Expressions;
using BlackArm.Application.Contracts;

namespace BlackArm.Infrastructure;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly ArmWrestlersDbContext _context;

    public RepositoryBase(ArmWrestlersDbContext context)
    {
        _context = context;
    }

    
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
    !trackChanges 
        ? _context.Set<T>()
            .Where(expression).AsNoTracking()
    : _context.Set<T>().Where(expression);


    public IQueryable<T> FindAll(bool trackChanges) => _context.Set<T>();
    public void Create(T entity) => _context.Set<T>().Add(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
 
}