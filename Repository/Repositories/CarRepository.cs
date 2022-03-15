using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CarRepository : AbstractRepository<Car, int>, ICarRepository
    {
		public CarRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Car entity) => entity.Id;

		protected override Car ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Car> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Car value)
		{
			_context.Cars.Add(value);
		}

		protected override async Task CreateImplementationAsync(Car value)
		{
			await _context.Cars.AddAsync(value);
		}

		protected override void UpdateImplementation(Car entity, Car value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Car value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Cars.Remove(entity);
		}

		protected override IQueryable<Car> QueryImplementation()
		{
			return _context.Cars
				.Include((m) => m.Model);
		}
		#endregion
	}
}
