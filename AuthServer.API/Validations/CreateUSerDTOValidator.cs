using AuthServer.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.API.Validations
{
    public class CreateUSerDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUSerDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is requared")
                .EmailAddress()
                .WithMessage("Email is wrong");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is requared");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User Name is requared");
        }
    }
}
