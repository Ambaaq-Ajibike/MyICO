using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Infrastructure.Database.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
         _context = context;
    }
    public async Task<T> Create(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
       return entity;
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var entity = await _context.Set<T>().ToListAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllByExpression(Expression<Func<T, bool>> expression)
    {
        var entity = await _context.Set<T>().Where(expression).ToListAsync();
        return entity;
    }

    public async Task<T> Update(T entity)
    {
         _context.Set<T>().Update(entity);
         return entity;
    }
    public async void SaveDbChanges()
    {
        await _context.SaveChangesAsync();
    }
}
