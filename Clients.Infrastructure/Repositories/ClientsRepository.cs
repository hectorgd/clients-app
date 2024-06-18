using Clients.Application.Interfaces;
using Clients.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clients.Infrastructure;

public class ClientsRepository : IClientsRepository
{
    public ClientsDataContext Context { get; set; }
    
    public ClientsRepository(ClientsDataContext context)
    {
        Context = context;
    }
    
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await Context.Clients.ToListAsync();
    }

    public async Task<Client> GetByIdAsync(Guid id)
    {
        return await Context.Clients.FindAsync(id);
    }

    public async Task<Guid> AddAsync(Client? client)
    {
        var entityEntry = await Context.Clients.AddAsync(client);
        await Context.SaveChangesAsync();
        return entityEntry.Entity.Id;
    }

    public Task UpdateAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        return Context.SaveChangesAsync();
    }
}