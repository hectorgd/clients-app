using Clients.Domain.Entities;
using MediatR;

namespace Clients.Application.Queries;

public class GetClientsQuery : IRequest<IEnumerable<Client>>
{
    
}