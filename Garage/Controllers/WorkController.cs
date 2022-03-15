using Business.Interop.Data;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IWorkTypeService _workTypeService;

        public WorkController(IWorkService workService, IWorkTypeService workTypeService)
        {
            _workService = workService;
            _workTypeService = workTypeService;
        }

        public IActionResult Index()
        {
            var works = _workService.GetAll();
            return View(works);
        }

        public IActionResult Details(int id)
        {
            var model = _workService.FindById(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new WorkDto() { Id = 1 };

            ViewData["WorkTypeIds"] = new SelectList(_workTypeService.GetAll(),
                dataValueField: nameof(WorkTypeDto.Id),
                dataTextField: nameof(WorkTypeDto.Name));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkDto dto)
        {
            if (_workService.ExistsByName(dto.Name))
                ModelState.AddModelError("Name", "Work with such name already exists");

            if (ModelState.IsValid)
            {
                _workService.CreateWork(dto);
                return RedirectToAction(nameof(Index));
            }

            ViewData["WorkTypeIds"] = new SelectList(_workTypeService.GetAll(),
                dataValueField: nameof(WorkTypeDto.Id),
                dataTextField: nameof(WorkTypeDto.Name),
                selectedValue: dto.WorkTypeId);
             
            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _workService.FindById(id);

            if (model == null)
                return NotFound();

            ViewData["WorkTypeIds"] = new SelectList(_workTypeService.GetAll(),
               dataValueField: nameof(WorkTypeDto.Id),
               dataTextField: nameof(WorkTypeDto.Name),
               selectedValue: model.WorkTypeId);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, WorkDto work)
        {
            if (id != work.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                _workService.UpdateWork(work);
                return RedirectToAction(nameof(Index));
            }

            return View(work);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var work = _workService.FindById(id);
            if (work == null)
                return NotFound();

            try 
            { 
                _workService.DeleteWork(work);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(work);
            }                     
        }
    }
}
