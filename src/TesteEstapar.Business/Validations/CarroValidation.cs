using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEstapar.Business.Models;
using TesteEstapar.Business.Validations.Docs;

namespace TesteEstapar.Business.Validations
{
    public class CarroValidation : AbstractValidator<Carro>
    {
        public CarroValidation()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => Utils.EPlacaValida(c.Placa)).Equal(true)
                .WithMessage("A placa fornecida é inválida.");

            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter 8 caracteres");


        }
    }
}
