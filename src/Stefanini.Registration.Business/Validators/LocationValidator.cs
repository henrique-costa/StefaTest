using FluentValidation;
using Stefanini.Registration.Domain.Dtos;

namespace Stefanini.Registration.Business.Validators
{
    public class LocationValidator : AbstractValidator<LocationDto>
    {
        public LocationValidator()
        {
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
        }
    }
}
