using Clients.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Infrastructure;

public class ClientsDataContext : DbContext
{
    public ClientsDataContext(DbContextOptions<ClientsDataContext> options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
}