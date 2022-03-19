using Business.Interop.Data;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq;

namespace Garage.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWorkService _workService;
        private readonly IMechanicService _mechanicService;
        private readonly IClientService _clientService;

        public OrderController(IOrderService orderService, IWorkService workService, 
            IMechanicService mechanicService, IClientService clientService)
        {
            _orderService = orderService;
            _workService = workService;
            _mechanicService = mechanicService;
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAll();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _orderService.GetDetailsById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new GarageOrderDto() { Id = 1};

            ViewData["ClientIds"] = new SelectList(_clientService.GetAll(),
                    dataValueField: nameof(ClientDto.Id),
                    dataTextField: nameof(ClientDto.FullName));

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(GarageOrderDto model)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPosition(int id)
        {
            var order = _orderService.FindById(id);
            if (order == null)
                return NotFound();

            var model = new OrderPositionDto() { Id = 0, OrderId = id, Order = order};

            ViewData["WorkIds"] = new SelectList(_workService.GetAll(),
                    dataValueField: nameof(WorkDto.Id),
                    dataTextField: nameof(WorkDto.Name));
            ViewData["MechanicIds"] = new SelectList(_mechanicService.GetAll(),
                    dataValueField: nameof(MechanicDto.Id),
                    dataTextField: nameof(MechanicDto.Name));

            return View(model);
        }

        [HttpPost]
        public IActionResult AddPosition(OrderPositionDto dto)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddPosition(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var order = _orderService.FindById(id);
            if (order == null)
                return NotFound();
            try
            {
                _orderService.DeleteOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
    }
}
