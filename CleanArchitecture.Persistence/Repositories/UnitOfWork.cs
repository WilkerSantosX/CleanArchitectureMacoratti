using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Gerencia o contexto e persistência das transações no banco de dados

        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;        
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            //Salva de modo atômico
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
