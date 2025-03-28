using AutoserviceAPI.Core.DTOs;
using AutoserviceAPI.Core.Entities;
using AutoserviceAPI.Infrastructure.Repositories.Repositories;

namespace AutoserviceAPI.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISupabaseClient _supabaseClient;

        public ClientRepository(ISupabaseClient supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
            var clientsResponse = await _supabaseClient.Client.From<Client>().Get();
            var clients = clientsResponse.Models;

            var clientIds = clients.Select(c => c.Id).ToList();

            var carsResponse = await _supabaseClient.Client.From<Car>().Get();
            var cars = carsResponse.Models;

            var clientDTOs = clients.Select(c => new ClientDTO //перенести в маппер
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                Cars = cars.Where(car => car.ClientId == c.Id).Select(car => new CarDTO
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    ClientId = c.Id,
                    Year = car.Year,
                    LicensePlate = car.LicensePlate
                }).ToList()
            }).ToList();

            return clientDTOs;
        }

        public async Task<List<CarDTO>> GetCarsByClientIdAsync(Guid clientId)
        {
            var carsResponse = await _supabaseClient.Client.From<Car>().Where(x => x.ClientId == clientId).Get();
            var cars = carsResponse.Models;

            return cars.Select(car => new CarDTO //перенести в маппер
            {
                Id = car.Id,
                ClientId = car.ClientId,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                LicensePlate = car.LicensePlate
            }).ToList();
        }

    }
}
