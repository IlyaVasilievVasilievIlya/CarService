using Business.Interop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IMechanicService
    {
        public IEnumerable<MechanicDto> GetAll();
        public IEnumerable<MechanicDto> FindByName(string name);
        public MechanicDto FindById(int id);
        public void DeleteMechanic(MechanicDto mechanic);
        public MechanicDto Create(MechanicDto mechanic);
    }
}
