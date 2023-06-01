using FluentValidation;
using Stefanini.Registration.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Business.Validators
{
    public class RegistrationValidator : AbstractValidator<CreateRegistrationDto>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.EventId).NotEmpty().WithMessage("Event is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
        }
    }
}
