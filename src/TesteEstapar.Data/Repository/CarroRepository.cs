using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Interfaces;
using TesteEstapar.Data.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteEstapar.Data.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(MeuDbContext context) : base(context){}

        public async Task<Carro> ObterCarro(Guid id)
        {
            return await Db.Carros.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
