using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class OrderRepository : AbstractRepository<GarageOrder, int>, IOrderRepository
	{
		public OrderRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(GarageOrder entity) => entity.Id;

		protected override GarageOrder ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<GarageOrder> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(GarageOrder value)
		{
			_context.Orders.Add(value);
		}

		protected override async Task CreateImplementationAsync(GarageOrder value)
		{
			await _context.Orders.AddAsync(value);
		}

		protected override void UpdateImplementation(GarageOrder entity, GarageOrder value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(GarageOrder value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Orders.Remove(entity);
		}

		protected override IQueryable<GarageOrder> QueryImplementation()
		{
			return _context.Orders
				.Include(c => c.ClientCar)
					.ThenInclude(c => c.Car)
					.ThenInclude(m => m.Model)
				.Include(c => c.ClientCar)
					.ThenInclude(c => c.Client)
				.Include(p => p.Positions)
					.ThenInclude(w => w.Work)
				.Include(p => p.Positions)
					.ThenInclude(m => m.Mechanic);
		}
		#endregion
	}
}
