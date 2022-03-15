using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IMapper _mapper;

        public WorkService(IWorkRepository workRepository, IWorkTypeRepository workTypeRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _workTypeRepository = workTypeRepository;
           _mapper = mapper;
        }

        public WorkDto CreateWork(WorkDto work)
        {
            var entity = _mapper.Map<Work>(work);
            _workRepository.Create(entity);
            return _mapper.Map<WorkDto>(entity);
        }

        public void DeleteWork(WorkDto work)
        {
            var entity = _mapper.Map<Work>(work);
            _workRepository.Delete(entity);
        }

        public WorkDto UpdateWork(WorkDto work)
        {
            var entity = _workRepository.Read(work.Id);
            var workType = _workTypeRepository.Read(work.WorkTypeId);

            entity.Name = work.Name;
            entity.Price = work.Price;
            entity.WorkType = workType;
            entity.WorkTypeId = workType.Id;
            
            _workRepository.Update(entity);

            var updatedEntity = _workRepository.Read(work.Id);
            return _mapper.Map<WorkDto>(updatedEntity);
        }

        public IEnumerable<WorkDto> GetAll()
        {
            var entities = _workRepository.Query();
            return _mapper.Map<List<Work>, IEnumerable<WorkDto>>(entities);
        }

        public bool ExistsByName(string name) =>
            _workRepository.Query().Exists((work) => work.Name.Equals(name));

        public WorkDto FindById(int id) 
        {
            var work = _workRepository.Read(id);
            return _mapper.Map<WorkDto>(work);
        }

        public IEnumerable<WorkDto> FindByName(string name)
        {
            var works = _workRepository.Query()
                .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(works);
        }
    }
}