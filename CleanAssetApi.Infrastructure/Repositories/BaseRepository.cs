using CleanAssetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CleanAssetApi.Infrastructure.DBInterfaces;

namespace CleanAssetApi.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public APIDbContext RepositoryContext { get; set; }
        public BaseRepository(APIDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();      
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }
    }
}
