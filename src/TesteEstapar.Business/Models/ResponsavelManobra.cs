using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Business.Models
{
    public class ResponsavelManobra : Entity
    {
        public Guid ManobristaId { get; set; }
        public Guid CarroId { get; set; }

        public Carro Carro { get; set; }
        public Manobrista Manobrista { get; set; }
    }
}
