using AutoMapper;
using Business.Entities;
using Business.Interop.Data;
using Business.Repositories.DataRepositories;
using Business.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class MechanicService : IMechanicService
    {
        private readonly IMechanicRepository _mechanicRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IMapper _mapper;

        public MechanicService(IMechanicRepository mechanicRepository, IWorkTypeRepository workTypeRepository, IMapper mapper)
        {
            _mechanicRepository = mechanicRepository;
            _workTypeRepository = workTypeRepository;
            _mapper = mapper;
        }

        public IEnumerable<MechanicDto> FindByName(string name)
        {
            var mechanics = _mechanicRepository.Query()
                .Where(i => i.Name.Contains(name, System.StringComparison.InvariantCultureIgnoreCase));

            return _mapper.Map<IEnumerable<Mechanic>, IEnumerable<MechanicDto>>(mechanics);
        }

        public IEnumerable<MechanicDto> GetAll()
        {
            var entities = _mechanicRepository.Query();
            return _mapper.Map<List<Mechanic>, IEnumerable<MechanicDto>>(entities);
        }

        public MechanicDto FindById(int id)
        {
            var mechanic = _mechanicRepository.Read(id);
            return _mapper.Map<MechanicDto>(mechanic);
        }

        public void DeleteMechanic(MechanicDto mechanic)
        {
            var entity = _mapper.Map<Mechanic>(mechanic);
            _mechanicRepository.Delete(entity);
        }

        public MechanicDto Create(MechanicDto mechanicDto)
        {
            var workScope = mechanicDto.WorkScopeId.Select(id => _workTypeRepository.Read(id)).ToList();
            var entity = _mapper.Map<Mechanic>(mechanicDto);
            entity.WorkScope = workScope;

            _mechanicRepository.CreateOrUpdate(entity);
            
            return mechanicDto;
        }
    }
}
