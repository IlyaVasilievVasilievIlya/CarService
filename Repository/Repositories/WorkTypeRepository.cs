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
    public class WorkTypeRepository : AbstractRepository<WorkType, int>, IWorkTypeRepository
	{
		public WorkTypeRepository(Context context)
		{
			_context = context;
		}

		#region implementation
		protected override int KeySelector(WorkType entity) => entity.Id;

		protected override WorkType ReadImplementation(int key)
		{
			return QueryImplementation().FirstOrDefault(i => i.Id == key);
		}

		protected override async Task<WorkType> ReadImplementationAsync(int key)
		{
			return await QueryImplementation().FirstOrDefaultAsync(i => i.Id == key);
		}

		protected override void CreateImplementation(WorkType value)
		{
			_context.WorkTypes.Add(value);
		}

		protected override async Task CreateImplementationAsync(WorkType value)
		{
			await _context.WorkTypes.AddAsync(value);
		}

		protected override void UpdateImplementation(WorkType entity, WorkType value)
		{
			_context.Update(value);
		}

		protected override void DeleteImplementation(WorkType value)
		{
			var entity = ReadImplementation(value.Id);
			if (entity == null) return;
			_context.WorkTypes.Remove(entity);
		}

		protected override IQueryable<WorkType> QueryImplementation()
		{
			return _context.WorkTypes
				.Include(m => m.Mechanics);
		}
		#endregion
	}
}
