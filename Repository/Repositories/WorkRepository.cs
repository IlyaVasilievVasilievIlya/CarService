using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class WorkRepository : AbstractRepository<Work, int>, IWorkRepository
    {
        public WorkRepository(Context context)
        {
            _context = context;
        }

		#region implementation
		protected override int KeySelector(Work entity) => entity.Id;

		protected override Work ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Work> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Work value)
		{
			_context.Works.Add(value);
		}

		protected override async Task CreateImplementationAsync(Work value)
		{
			await _context.Works.AddAsync(value);
		}

		protected override void UpdateImplementation(Work entity, Work value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Work value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Works.Remove(entity);
		}

		protected override IQueryable<Work> QueryImplementation()
		{
			return _context.Works
				.Include(w => w.WorkType);
		}
		#endregion
	}
}
