using BLL.DesignPatterns.GenericRepositoryPattern.IntRep;
using DAL.Context;
using ENTITIES.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DesignPatterns.GenericRepositoryPattern.BaseRep
{
    public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.Status = Status.Passive;
            entity.DeleteDate = DateTime.Now;
            await SaveChanges();
        }

        public TEntity Find(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChanges();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression).ToList();
        }
    }
}
