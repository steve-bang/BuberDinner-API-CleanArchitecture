using BuberDinner.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Behaviors
{

    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                var context = await _validator.ValidateAsync(request, cancellationToken);

                var failures = _validator
                    .Validate(request)
                    .Errors
                    .Where(f => f != null)
                    .Select(f => new ValidationFailure(f.PropertyName, f.ErrorMessage))
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new BadRequestException(failures.First().ErrorMessage);
                }
            }
            return await next();
        }
    }
}
