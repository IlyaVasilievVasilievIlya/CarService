using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ClientRepository : AbstractRepository<Client, int>, IClientRepository
    {
		public ClientRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Client entity) => entity.Id;

		protected override Client ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Client> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Client value)
		{
			_context.Clients.Add(value);
		}

		protected override async Task CreateImplementationAsync(Client value)
		{
			await _context.Clients.AddAsync(value);
		}

		protected override void UpdateImplementation(Client entity, Client value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Client value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Clients.Remove(entity);
		}

		protected override IQueryable<Client> QueryImplementation()
		{
			return _context.Clients
				.Include((c) => c.Cars)
					.ThenInclude((m) => m.Car)
					.ThenInclude((m) => m.Model);
		}
		#endregion
	}
}
