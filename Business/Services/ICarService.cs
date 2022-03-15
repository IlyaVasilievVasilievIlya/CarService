using Business.Interop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface ICarService
    {
        public IEnumerable<CarDto> GetAll();
    }
}
