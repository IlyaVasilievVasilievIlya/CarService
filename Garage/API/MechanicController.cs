using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Garage.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : Controller
    {
        private readonly IMechanicService _mechanicService;
        public MechanicController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        [HttpGet("find/{name}")]
        public JsonResult FindByName(string name)
        {
            return Json(_mechanicService.FindByName(name));
        }
    }
}
