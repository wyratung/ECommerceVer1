using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.V1.Command.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<CreateOrderCommand> context, CancellationToken cancellation = default)
        {
            var instance = context.InstanceToValidate;
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(150).WithMessage("Username must not exceed 150 characters.");

            RuleFor(x => x.EmailAddress)
                .EmailAddress().WithMessage($"{instance.EmailAddress} is invalid Email format.");

            return base.ValidateAsync(context, cancellation);
        }
    }
}
