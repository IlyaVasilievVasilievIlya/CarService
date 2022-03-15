using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Garage.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet("find/{name}")]
        public JsonResult FindByName(string name)
        {
            return Json(_workService.FindByName(name));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var work = _workService.FindById(id);
            if (work == null)
                return NotFound();

            return Ok(work);
        }
    }
}
