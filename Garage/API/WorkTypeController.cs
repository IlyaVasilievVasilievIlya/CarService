using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Garage.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : Controller
    {
        private readonly IWorkTypeService _workTypeService;

        public WorkTypeController(IWorkTypeService workTypeService)
        {
            _workTypeService = workTypeService;
        }

        [HttpGet("getMechanics/{id}")]
        public IActionResult GetWorkTypeMechanics(int id)
        {
            if (_workTypeService.FindById(id) == null)
                return NotFound();

            var mechanics = _workTypeService.GetConnectedMechanics(id);
            return Ok(mechanics);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var workType = _workTypeService.FindById(id);
            if (workType == null)
                return NotFound();

            return Ok(workType);
        }
    }
}
