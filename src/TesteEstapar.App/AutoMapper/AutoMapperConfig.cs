using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEstapar.Business.Models;
using TesteEstapar.App.ViewModels;

namespace TesteEstapar.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Carro, CarroViewModel>().ReverseMap();
            CreateMap<Manobrista, ManobristaViewModel>().ReverseMap();
            CreateMap<ResponsavelManobra, ResponsavelManobraViewModel>().ReverseMap();
        }
    }
}
