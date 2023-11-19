using Microsoft.EntityFrameworkCore;
using Store.Models.Entities.Common;
using System.Linq.Expressions;

namespace Store.Models.Services.Common;


public class Service<TEntity, TContext> : IService<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
{
    public async Task Add(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = new TContext().Set<TEntity>();

        if (filter != null)
            query = query.Where(filter);

        query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return orderBy != null
            ? await orderBy(query).ToListAsync()
            : await query.ToListAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
    {
        IQueryable<TEntity> query = new TContext().Set<TEntity>();

        if (filter != null)
            query = query.Where(filter);

        query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.FirstOrDefaultAsync();
    }

    public async Task Update(TEntity entity)
    {
        using (TContext context = new TContext())
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

