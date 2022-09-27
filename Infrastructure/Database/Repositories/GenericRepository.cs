
namespace Infrastructure.Database.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    public async Task<T> Create(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetAllByExpression(System.Linq.Expressions.Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
