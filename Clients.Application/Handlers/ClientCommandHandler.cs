using Clients.Application.Commands;
using Clients.Application.Interfaces;
using Clients.Application.Validators;
using Clients.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Clients.Application.Handlers;

public class ClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>, IRequestHandler<UpdateClientCommand,Guid>
                                    ,IRequestHandler<DeleteClientCommand, bool>
{
    private readonly IClientsRepository _clientRepository;
    private readonly IValidator<CreateClientCommand> _createClientCommandValidator;
    private readonly IValidator<UpdateClientCommand> _updateClientCommandValidator;

    public ClientCommandHandler(IClientsRepository clientRepository, IValidator<CreateClientCommand> createClientCommandValidator,
        IValidator<UpdateClientCommand> updateClientCommandValidator)
    {
        _clientRepository = clientRepository;
        _createClientCommandValidator = createClientCommandValidator;
        _updateClientCommandValidator = updateClientCommandValidator;
    }
    
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = _createClientCommandValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ApplicationException(validationResult.ToString());
        }
        
        var client = new Client()
        {
            Name = request.Name,
            LastName = request.LastName,
            Genre = request.Genre,
            BirthDate = request.BirthDate,
            Address = request.Address,
            Country = request.Country,
            PostalCode = request.PostalCode,
            Email = request.Email
        };

        var userId =await _clientRepository.AddAsync(client);
        await _clientRepository.SaveChangesAsync();

        return userId;
    }

    public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = _updateClientCommandValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ApplicationException(validationResult.ToString());
        }
        
        Client client = await _clientRepository.GetByIdAsync(request.Id);

        if (client == null)
        {
            throw new ApplicationException($"Client with id {request.Id} not found.");
        }
        
        client.Name = request.Name;
        client.LastName = request.LastName;
        
        await _clientRepository.UpdateAsync(client);
        await _clientRepository.SaveChangesAsync();
        return client.Id;
    }

    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetByIdAsync(request.Id);
        
        if (client == null)
        {
            throw new ApplicationException($"Client with id {request.Id} not found.");
        }
        await _clientRepository.DeleteAsync(client);
        return true;
    }
}