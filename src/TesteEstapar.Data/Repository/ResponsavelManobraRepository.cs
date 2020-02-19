using System;
using System.Collections.Generic;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TesteEstapar.Data.Repository
{
    public class ResponsavelManobraRepository : Repository<ResponsavelManobra>, IResponsavelManobraRepository
    {
        public ResponsavelManobraRepository(MeuDbContext context) : base(context) { }

        public async Task<ResponsavelManobra> ObterResponsavelManobra(Guid id)
        {
            return await Db.ResponsaveisManobras.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ResponsavelManobra> ObterResponsavelManobristaCarro(Guid id)
        {
            return await Db.ResponsaveisManobras.AsNoTracking().Include(c => c.Manobrista).Include(d => d.Carro)
           .FirstOrDefaultAsync(e=>e.Id == id);
        }

        public async Task<IEnumerable<ResponsavelManobra>> ObterTodosResponsavelManobristaCarro()
        {
            return await Db.ResponsaveisManobras.AsNoTracking().Include(c => c.Manobrista).Include(d => d.Carro)
           .ToListAsync();
        }
    }
}
