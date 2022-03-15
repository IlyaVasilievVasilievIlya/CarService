using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class ClientCarRepository : AbstractRepository<ClientCar, int>, IClientCarRepository
	{
		public ClientCarRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(ClientCar entity) => entity.Id;

		protected override ClientCar ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<ClientCar> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(ClientCar value)
		{
			_context.ClientCars.Add(value);
		}

		protected override async Task CreateImplementationAsync(ClientCar value)
		{
			await _context.ClientCars.AddAsync(value);
		}

		protected override void UpdateImplementation(ClientCar entity, ClientCar value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(ClientCar value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.ClientCars.Remove(entity);
		}

		protected override IQueryable<ClientCar> QueryImplementation()
		{
			return _context.ClientCars
				.Include(c => c.Client)
				.Include(c => c.Car);
		}
		#endregion
	}
}

