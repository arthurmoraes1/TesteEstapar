using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.App.ViewModels
{
    public class CarroViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Marca { get; set; }

        public ResponsavelManobraViewModel ResponsavelManobra { get; set; }

    }
}
