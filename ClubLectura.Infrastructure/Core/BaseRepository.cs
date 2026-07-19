using ClubLectura.Domain.Core;
using ClubLectura.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClubLectura.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ClubLecturaContext _context;
        protected readonly DbSet<TEntity> _entities;

        protected BaseRepository(ClubLecturaContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _entities.Where(e => !e.Borrado).ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<bool> Exists(int id)
        {
            return await _entities.AnyAsync(e => e.Id == id && !e.Borrado);
        }

        public virtual async Task Save(TEntity entity)
        {
            entity.FechaCreacion = DateTime.Now;
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

   
        public virtual async Task Remove(TEntity entity)
        {
            entity.Borrado = true;
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
