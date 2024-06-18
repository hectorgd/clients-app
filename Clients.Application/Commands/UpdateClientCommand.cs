using Clients.Application.Interfaces.Commands;
using MediatR;

namespace Clients.Application.Commands;

public class UpdateClientCommand : IRequest<Guid>, IClientCommand
{   
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Genre { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    
    public UpdateClientCommand(string id,string name, string lastName, string genre, DateTime birthDate, string address, string country, string postalCode, string email)
    {
        Id = Guid.Parse(id);
        Name = name;
        LastName = lastName;
        Genre = genre;
        BirthDate = birthDate;
        Address = address;
        Country = country;
        PostalCode = postalCode;
        Email = email;
    }
}