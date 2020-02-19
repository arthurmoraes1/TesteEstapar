using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.Business.Models
{
    public class Manobrista : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<ResponsavelManobra> ResponsavelManobras { get; set; }
    }
}
