using Clients.Domain.Entities;

namespace Clients.Application.Interfaces;

public interface IClientsRepository
{
    // Obtener todos los elementos TodoItem
    Task<IEnumerable<Client>> GetAllAsync();

    // Obtener un elemento TodoItem específico por su Id
    Task<Client> GetByIdAsync(Guid id);

    // Agregar un nuevo elemento TodoItem
    Task<Guid> AddAsync(Client? client);

    // Actualizar un elemento TodoItem existente
    Task UpdateAsync(Client todoItem);

    // Eliminar un elemento TodoItem específico por su Id
    Task DeleteAsync(Client id);

    // Guardar los cambios en la base de datos
    Task SaveChangesAsync();
}