using Business.Entities;
using Business.Interop.Data;
using System.Collections.Generic;

namespace Business.Services
{
    public interface IWorkService
    {
        public IEnumerable<WorkDto> GetAll();
        public WorkDto CreateWork(WorkDto work);
        public WorkDto UpdateWork(WorkDto work);
        public void DeleteWork(WorkDto work);
        public WorkDto FindById(int id);
        public bool ExistsByName(string name);
        public IEnumerable<WorkDto> FindByName(string name);
    }
}
