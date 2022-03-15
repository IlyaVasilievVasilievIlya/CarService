using Business.Interop.Data;
using Business.Interop.Data.GarageOrderModels;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IOrderService
    {
        public IEnumerable<GarageOrderDto> GetAll();
        public GarageOrderDto CreateOrder(GarageOrderDto order);
        public GarageOrderDto FindById(int id);
        public void DeleteOrder(GarageOrderDto order);
        public OrderPositionDto AddPosition(OrderPositionDto dto);
        public OrderDetailsDto GetDetailsById(int id);
    }
}
