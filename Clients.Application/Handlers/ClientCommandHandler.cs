using Clients.Application.Commands;
using Clients.Application.Interfaces;
using Clients.Domain.Entities;
using MediatR;

namespace Clients.Application.Handlers;

public class ClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly IClientsRepository _repository;

    public ClientCommandHandler(IClientsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
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

        var userId =await _repository.AddAsync(client);
        await _repository.SaveChangesAsync();

        return userId;
    }
}