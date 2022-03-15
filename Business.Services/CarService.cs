using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System.Collections.Generic;


namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _CarRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository CarRepository, IMapper mapper)
        {
            _CarRepository = CarRepository;
            _mapper = mapper;
        }

        public IEnumerable<CarDto> GetAll()
        {
            var entities = _CarRepository.Query();
            return _mapper.Map<List<Car>, IEnumerable<CarDto>>(entities);
        }
    }
}
