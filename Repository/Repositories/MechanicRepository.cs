using Business.Entities;
using Business.Repositories.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MechanicRepository : AbstractRepository<Mechanic, int>, IMechanicRepository
    {
		public MechanicRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(Mechanic entity) => entity.Id;

		protected override Mechanic ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<Mechanic> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(Mechanic value)
		{
			_context.Mechanics.Add(value);
		}

		protected override async Task CreateImplementationAsync(Mechanic value)
		{
			await _context.Mechanics.AddAsync(value);
		}

		protected override void UpdateImplementation(Mechanic entity, Mechanic value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(Mechanic value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.Mechanics.Remove(entity);
		}

		protected override IQueryable<Mechanic> QueryImplementation()
		{
			return _context.Mechanics
				.Include(w => w.WorkScope);
		}
		#endregion
	}
}
