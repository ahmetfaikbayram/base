using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.DAL
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetList();
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetListWithSpec(ISpecification<T> spec);
        Task<int> Count(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}