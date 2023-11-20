using Store.Models.Entities.Common;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Store.Models.Services.Common;

public interface IService<T> where T : class, IEntity, new()
{
    Task<List<T>> List(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
    Task<T?> Get(Expression<Func<T, bool>> filter, string includeProperties = "");
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<int> Count(Expression<Func<T, bool>>? filter = null);
}
