using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientDto> GetAll()
        {
            var entities = _clientRepository.Query();
            return _mapper.Map<List<Client>, IEnumerable<ClientDto>>(entities);
        }

        public IEnumerable<ClientDto> FindByName(string name)
        {
            var clients = _clientRepository.Query()
                .Where(i => i.FullName.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);
        }

        public IEnumerable<CarDto> FindClientCars(int id)
        {
            var clientCars = _clientRepository.Read(id).Cars.Select(c => c.Car); 
            return _mapper.Map<IEnumerable<Car>, IEnumerable<CarDto>>(clientCars);
        }
    }
}
