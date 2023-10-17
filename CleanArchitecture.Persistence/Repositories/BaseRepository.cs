using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        //Contexto do banco via injeção de dependência
        protected readonly AppDbContext Context;
        public BaseRepository(AppDbContext context) 
        {
            Context = context;
        }

        void IBaseRepository<T>.Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        void IBaseRepository<T>.Delete(T entity)
        {
            entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        async Task<T> IBaseRepository<T>.Get(Guid id, CancellationToken cancellationToken)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        async Task<IEnumerable<T>> IBaseRepository<T>.GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        void IBaseRepository<T>.Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }
    }
}
