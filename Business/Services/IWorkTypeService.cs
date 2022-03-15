using Business.Interop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IWorkTypeService 
    {
        public IEnumerable<WorkTypeDto> GetAll();
        public IEnumerable<MechanicDto> GetConnectedMechanics(int id);
        public WorkTypeDto FindById(int id);
    }
}
