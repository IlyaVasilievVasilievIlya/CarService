using Business.Interop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IClientService
    {
        public IEnumerable<ClientDto> GetAll();
        public IEnumerable<ClientDto> FindByName(string name);
        public IEnumerable<CarDto> FindClientCars(int id);
    }
}
