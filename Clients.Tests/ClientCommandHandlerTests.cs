using Clients.Application.Commands;
using Clients.Application.Handlers;
using Clients.Application.Interfaces;
using Clients.Domain.Entities;
using FluentValidation;
using Moq;

namespace Clients.Tests;

public class ClientCommandHandlerTests
{
    private readonly Mock<IClientsRepository> _mockClientRepository;
    private readonly Mock<IValidator<CreateClientCommand>> _mockCreateClientCommandValidator;
    private readonly Mock<IValidator<UpdateClientCommand>> _mockUpdateClientCommandValidator;
    private readonly ClientCommandHandler _handler;

    public ClientCommandHandlerTests()
    {
        _mockClientRepository = new Mock<IClientsRepository>();
        _mockCreateClientCommandValidator = new Mock<IValidator<CreateClientCommand>>();
        _mockUpdateClientCommandValidator = new Mock<IValidator<UpdateClientCommand>>();
        _handler = new ClientCommandHandler(_mockClientRepository.Object, _mockCreateClientCommandValidator.Object, _mockUpdateClientCommandValidator.Object);
    }

    [Test]
    public async Task Handle_CreateClientCommand_ReturnsGuid()
    {
        var command = new CreateClientCommand("John", "Doe", "Male", DateTime.Now, "123 Street", "USA", "12345", "john.doe@example.com");
        _mockCreateClientCommandValidator.Setup(v => v.Validate(command)).Returns(new FluentValidation.Results.ValidationResult());
        _mockClientRepository.Setup(r => r.AddAsync(It.IsAny<Client>())).ReturnsAsync(Guid.NewGuid());
        
        var result = await _handler.Handle(command, CancellationToken.None);
        
        Assert.IsInstanceOf<Guid>(result);
    }
}