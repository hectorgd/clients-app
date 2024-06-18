using MediatR;

namespace Clients.Application.Commands;

public class DeleteClientCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    
    public DeleteClientCommand(string id)
    {
        Id = Guid.Parse(id);
    }
}