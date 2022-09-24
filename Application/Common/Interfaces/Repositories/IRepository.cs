using System.Linq.Expressions;


namespace Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T Create(T entity);
    T Update(T entity);
    T Get(Expression<Func<T, bool>> expression);
    T GetAll();
    T GetAllByExpression(Expression<Func<T, bool>> expression);
}
