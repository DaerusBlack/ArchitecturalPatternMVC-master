using ENTITIES.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DesignPatterns.GenericRepositoryPattern.IntRep
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Find(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        List<T> Where(Expression<Func<T, bool>> expression);
        T GetDefault(Expression<Func<T, bool>> expression);
    }
}
