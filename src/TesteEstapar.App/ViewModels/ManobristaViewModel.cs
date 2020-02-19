using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.App.ViewModels
{
    public class ManobristaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0}  e de preenchimento obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter 11 caracteres")]
        public string Cpf { get; set; }
        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }

        public ResponsavelManobraViewModel ResponsavelManobra { get; set; }
    }
}
