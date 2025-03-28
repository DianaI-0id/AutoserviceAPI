using AutoserviceAPI.Core.DTOs;
using AutoserviceAPI.Core.Entities;

namespace AutoserviceAPI.Infrastructure.Repositories.Repositories
{
    public interface IClientRepository
    {
        Task<List<ClientDTO>> GetAllClientsAsync();
        Task<List<CarDTO>> GetCarsByClientIdAsync(Guid clientId);
    }
}
