using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderPositionRepository : AbstractRepository<OrderPosition, int>, IOrderPositionRepository
    {
        public OrderPositionRepository(Context context)
        {
            _context = context;
        }

		#region implementation
		protected override int KeySelector(OrderPosition entity) => entity.Id;

		protected override OrderPosition ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<OrderPosition> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(OrderPosition value)
		{
			_context.OrderPositions.Add(value);
		}

		protected override async Task CreateImplementationAsync(OrderPosition value)
		{
			await _context.OrderPositions.AddAsync(value);
		}

		protected override void UpdateImplementation(OrderPosition entity, OrderPosition value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(OrderPosition value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.OrderPositions.Remove(entity);
		}

		protected override IQueryable<OrderPosition> QueryImplementation()
		{
			return _context.OrderPositions
				.Include(g => g.Order)
				.Include(m => m.Mechanic)
				.Include(w => w.Work);
		}
		#endregion
	}
}
