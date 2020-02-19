using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Validations.Docs;

namespace TesteEstapar.Business.Validations
{
    public class ManobristaValidation : AbstractValidator<Manobrista>
    {
        public ManobristaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c=>c.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Cpf precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(c => CpfValidacao.Validar(c.Cpf)).Equal(true)
                .WithMessage("O cpf fornecido é inválido.");
            RuleFor(c => c.DataNascimento.Date).LessThan(DateTime.Now).WithMessage("A data é inválida.");
                
        }
    }
}
