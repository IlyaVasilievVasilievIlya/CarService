using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Interop.Data.GarageOrderModels;
using Business.Repositories.DataRepositories;
using Business.Services.Exceptions;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderPositionRepository _orderPositionRepository;
        private readonly IClientCarRepository _clientCarRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IClientCarRepository clientCarRepository, IOrderPositionRepository orderPositionRepository,  IMapper mapper)
        {
            _orderRepository = orderRepository;
            _clientCarRepository = clientCarRepository;
            _orderPositionRepository = orderPositionRepository;
           _mapper = mapper;
        }

        public GarageOrderDto CreateOrder(GarageOrderDto order)
        {
            var clientCar = _clientCarRepository.Query()
                .Find((clientCar) => clientCar.Car.Id == order.ClientCar.CarId
            && clientCar.Client.Id == order.ClientCar.ClientId);
            if (clientCar == null)
                throw new RecourceNotFoundException("Client car doesn't exist");

            var entity = _mapper.Map<GarageOrder>(order);
            entity.ClientCar = clientCar;

            _orderRepository.Create(entity);
            return _mapper.Map<GarageOrderDto>(order);
        }

        public IEnumerable<GarageOrderDto> GetAll()
        {
            var entities = _orderRepository.Query();
            return _mapper.Map<List<GarageOrder>, IEnumerable<GarageOrderDto>>(entities);
        }

        public GarageOrderDto FindById(int id)
        {
            var order = _orderRepository.Read(id);
            return _mapper.Map<GarageOrder, GarageOrderDto>(order);
        }

        public void DeleteOrder(GarageOrderDto order)
        {
            var entity = _mapper.Map<GarageOrder>(order);
            _orderRepository.Delete(entity);
        }

        public OrderPositionDto AddPosition(OrderPositionDto dto)
        {
            var entity = _mapper.Map<OrderPosition>(dto);
            _orderPositionRepository.Create(entity);
            return _mapper.Map<OrderPositionDto>(entity); ;
        }

        public OrderDetailsDto GetDetailsById(int id)
        {
            var model = _orderRepository.Read(id);
            return _mapper.Map<OrderDetailsDto>(model);
        }
    }
}
