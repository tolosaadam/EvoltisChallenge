using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Commands.Product.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(m => m.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithMessage(ValidationMessagesConstants.Empty)
            .NotNull()
                .WithMessage(ValidationMessagesConstants.Null)
            .NotEqual(default(Guid))
                .WithMessage(ValidationMessagesConstants.EmptyGuid);

        RuleFor(m => m.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(ValidationMessagesConstants.Empty)
                .NotNull()
                    .WithMessage(ValidationMessagesConstants.Null);

        RuleFor(m => m.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(ValidationMessagesConstants.Empty)
                .NotNull()
                    .WithMessage(ValidationMessagesConstants.Null);

        RuleFor(m => m.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                    .WithMessage(ValidationMessagesConstants.GreaterThanZero)
                .NotNull()
                    .WithMessage(ValidationMessagesConstants.Null);

        RuleFor(m => m.ProductCategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage(ValidationMessagesConstants.Empty)
                .NotNull()
                    .WithMessage(ValidationMessagesConstants.Null)
                .NotEqual(default(Guid))
                    .WithMessage(ValidationMessagesConstants.EmptyGuid);
    }
}
