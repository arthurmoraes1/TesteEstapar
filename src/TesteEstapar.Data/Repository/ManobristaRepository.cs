using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TesteEstapar.Data.Repository
{
    public class ManobristaRepository : Repository<Manobrista>, IManobristaRepository
    {
        public ManobristaRepository(MeuDbContext context) : base(context) { }

        public async Task<Manobrista> ObterManobrista(Guid id)
        {
            return await Db.Manobristas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
