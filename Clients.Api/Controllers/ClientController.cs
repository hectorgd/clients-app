using Clients.Application.Commands;
using Clients.Application.Queries;
using Clients.Contracts.Requests;
using Clients.Contracts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace clients_app.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateClient([FromBody] CreateClientContract contract)
    {
        var command = new CreateClientCommand(contract.Name, contract.LastName, contract.Genre, contract.BirthDate,
            contract.Address, contract.Country, contract.PostalCode, contract.Email);
        
        var clientId = await _mediator.Send(command);
        return Ok(clientId);
    }
    
    [HttpGet]
    [Route("{clientId}")]
    public async Task<ActionResult> GetClient(string clientId)
    {
        var command = new GetClientQuery(clientId);
        
        var client = await _mediator.Send(command);
        
        return Ok(client);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetClients()
    {
        var command = new GetClientsQuery();
        
        var clients = await _mediator.Send(command);
        
        return Ok(clients);
    }
}