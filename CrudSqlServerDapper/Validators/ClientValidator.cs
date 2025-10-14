using CrudSqlServerDapper.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .Length(2, 100).WithMessage("O nome do cliente deve ter entre 2 e 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do cliente é obrigatório.")
                .EmailAddress().WithMessage("O email do cliente deve ser um endereço de email válido.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento do cliente é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento do cliente deve ser uma data no passado.");
        }
    }
}
