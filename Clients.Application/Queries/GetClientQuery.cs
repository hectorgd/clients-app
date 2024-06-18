using Clients.Domain.Entities;
using MediatR;

namespace Clients.Application.Queries;

public class GetClientQuery : IRequest<Client>
{
    public Guid Id { get; set; }
    
    public GetClientQuery(string id)
    {
        Id = Guid.Parse(id);
    }
}