using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Garage.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("find/{name}")]
        public JsonResult FindByName(string name)
        {
            return Json(_clientService.FindByName(name));
        }

        [HttpGet("findCar/{id}")]
        public JsonResult FindClientCars(int id)
        {
            return Json(_clientService.FindClientCars(id));
        }
    }
}
