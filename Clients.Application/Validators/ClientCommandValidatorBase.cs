using Clients.Application.Interfaces.Commands;
using FluentValidation;

namespace Clients.Application.Validators;

public abstract class ClientCommandValidatorBase<T> : AbstractValidator<T> where T : IClientCommand
{
    protected ClientCommandValidatorBase()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName is required.");
        
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
        
        RuleFor(c => c.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.")
            .Matches(@"^\d{5}$").WithMessage("PostalCode is not valid.");
        
    }
}