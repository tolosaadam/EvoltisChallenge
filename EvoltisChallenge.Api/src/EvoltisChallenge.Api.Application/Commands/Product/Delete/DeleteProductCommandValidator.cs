using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Commands.Product.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(m => m.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(ValidationMessagesConstants.Empty)
                .NotNull()
                    .WithMessage(ValidationMessagesConstants.Null)
                .NotEqual(default(Guid))
                    .WithMessage(ValidationMessagesConstants.EmptyGuid);
    }
}
