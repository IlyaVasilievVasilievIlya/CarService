using Business.Interop.Data;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage.Controllers
{
    public class MechanicController : Controller
    {
        private readonly IMechanicService _mechanicService;
        private readonly IWorkTypeService _workTypeService;

        public MechanicController(IMechanicService mechanicService, IWorkTypeService workTypeService)
        {
            _mechanicService = mechanicService;
            _workTypeService = workTypeService;
        }

        public IActionResult Index()
        {
            var mechanics = _mechanicService.GetAll();
            return View(mechanics);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var model = _mechanicService.FindById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new MechanicDto() { Id = 1 };

            ViewData["WorkScopeIds"] = new SelectList(_workTypeService.GetAll(),
                dataValueField: nameof(WorkTypeDto.Id),
                dataTextField: nameof(WorkTypeDto.Name));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MechanicDto dto)
        {
            if (ModelState.IsValid)
            {
                _mechanicService.Create(dto);
                return RedirectToAction(nameof(Index));
            }

            ViewData["WorkScopeIds"] = new SelectList(_workTypeService.GetAll(),
                dataValueField: nameof(WorkTypeDto.Id),
                dataTextField: nameof(WorkTypeDto.Name),
                selectedValue: dto.WorkScopeId);

            return View(dto);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var mechanic = _mechanicService.FindById(id);
            if (mechanic == null)
                return NotFound();
            try
            {
                _mechanicService.DeleteMechanic(mechanic);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(mechanic);
            }
        }
    }
}
