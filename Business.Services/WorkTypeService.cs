using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using Business.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IMapper _mapper;

        public WorkTypeService(IWorkTypeRepository repository, IMapper mapper)
        {
            _workTypeRepository = repository;
            _mapper = mapper;
        }

        public IEnumerable<WorkTypeDto> GetAll()
        {
            var entities = _workTypeRepository.Query();
            return _mapper.Map<List<WorkType>, IEnumerable<WorkTypeDto>>(entities);
        }

        public IEnumerable<MechanicDto> GetConnectedMechanics(int id)
        {
            var mechanics = _workTypeRepository.Read(id).Mechanics;
            return _mapper.Map<IEnumerable<Mechanic>, IEnumerable<MechanicDto>>(mechanics);
        }

        public WorkTypeDto FindById(int id)
        {
            var entity = _workTypeRepository.Read(id);
            return _mapper.Map<WorkType, WorkTypeDto>(entity);
        }
    }
}
