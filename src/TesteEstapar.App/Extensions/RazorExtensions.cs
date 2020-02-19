using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteEstapar.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataPlaca(this RazorPage page, string placa)
        {
            var result = placa.Insert(3,"-");
            return result;
        }

        public static string FormataCpf(this RazorPage page, string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}
