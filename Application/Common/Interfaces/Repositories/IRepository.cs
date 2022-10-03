using System.Linq.Expressions;


namespace Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Create(T entity);

    Task<T> Update(T entity);

    Task<T> Get(string query);

    Task<IEnumerable<T>> GetAll(string query);
    
    Task<IEnumerable<T>> GetAllByExpression(string query);
    void SaveDbChanges();
}
