using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
     IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationBehavior(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationResuls = await Task.WhenAll(_validators.Select(
                v => v.ValidateAsync(context, cancellationToken)));

            IEnumerable<ValidationFailure> failures = (IEnumerable<ValidationFailure>)validationResuls.Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors.ToList());
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
