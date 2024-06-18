namespace Clients.Domain.Entities;

/// <summary>
/// Client entity that represents a client in the system.
/// </summary>
public class Client
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
}