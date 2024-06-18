namespace Clients.Application.Interfaces.Commands;

public interface IClientCommand
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Genre { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
}