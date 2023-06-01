using FluentValidation;
using Stefanini.Registration.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Registration.Business.Validators
{
    public class UpdateEventValidator : AbstractValidator<UpdateEventDto>
    {
        public UpdateEventValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.AvailableSeats).NotEmpty().WithMessage("AvailableSeats is required");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Active status is required");
            RuleFor(x => x.EventLocationId).NotEmpty().WithMessage("Location Id is required");
        }        
    }
}
