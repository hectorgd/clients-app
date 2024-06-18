using Clients.Application.Commands;
using Clients.Application.Interfaces;
using Clients.Application.Queries;
using Clients.Domain.Entities;
using MediatR;

namespace Clients.Application.Handlers;

public class ClientQueryHandler : IRequestHandler<GetClientQuery, Client>, IRequestHandler<GetClientsQuery, IEnumerable<Client>>
{
    private readonly IClientsRepository _clientRepository;

    public ClientQueryHandler(IClientsRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<Client> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        return _clientRepository.GetByIdAsync(request.Id);
        
    }

    public Task<IEnumerable<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return _clientRepository.GetAllAsync();
    }
}