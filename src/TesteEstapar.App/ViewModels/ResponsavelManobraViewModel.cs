using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.App.ViewModels
{
    public class ResponsavelManobraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Manobrista")]
        public Guid ManobristaId { get; set; }
        
        [DisplayName("Carro")]
        public Guid CarroId { get; set; }

        public CarroViewModel Carro { get; set; }
        public IEnumerable<CarroViewModel> Carros { get; set; }
        public ManobristaViewModel Manobrista { get; set; }
        public IEnumerable<ManobristaViewModel> Manobristas { get; set; }
    }
}
