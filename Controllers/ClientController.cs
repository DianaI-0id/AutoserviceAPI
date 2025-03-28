using AutoserviceAPI.Core.DTOs;
using AutoserviceAPI.Core.Entities;
using AutoserviceAPI.Infrastructure.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AutoserviceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> GetAll()
        {
            var clients = await _clientRepository.GetAllClientsAsync();
            return clients;
        }

        [HttpGet("cars/{clientId}")]
        public async Task<ActionResult<List<CarDTO>>> GetCarsByClientIdAsync(Guid clientId)
        {
            try
            {
                var cars = await _clientRepository.GetCarsByClientIdAsync(clientId);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
