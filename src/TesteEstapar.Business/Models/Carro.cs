using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Business.Models
{
    public class Carro : Entity
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }

        public ICollection<ResponsavelManobra> ResponsavelManobras { get; set; }

    }
}
