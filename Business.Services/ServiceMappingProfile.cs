using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Interop.Data.GarageOrderModels;
using Business.Interop.Data.OrderPositionModels;

namespace Business.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            // From entity to dto
            CreateMap<Work, WorkDto>();
            CreateMap<WorkType, WorkTypeDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Car, CarDto>();
            CreateMap<GarageOrder, GarageOrderDto>();
            CreateMap<GarageOrder, OrderDetailsDto>();
            CreateMap<OrderPosition, OrderPositionDto>();
            CreateMap<OrderPosition, OrderPositionDetailsDto>();
            CreateMap<Mechanic, MechanicDto>();
            CreateMap<ClientCar, ClientCarDto>();
            CreateMap<CarModel, CarModelDto>();
            
            // From dto to entity
            CreateMap<WorkDto, Work>();
            CreateMap<WorkTypeDto, WorkType>();
            CreateMap<ClientDto, Client>();
            CreateMap<CarDto, Car>();
            CreateMap<GarageOrderDto, GarageOrder>();
            CreateMap<OrderPositionDto, OrderPosition>();
            CreateMap<MechanicDto, Mechanic>();
            CreateMap<ClientCarDto, ClientCar>();
            CreateMap<CarModelDto, CarModel>();

        }
    }
}
