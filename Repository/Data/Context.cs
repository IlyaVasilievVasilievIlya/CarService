using Business.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository.Data
{
	public class Context : DbContext
	{
		public DbSet<WorkType> WorkTypes { get; set; }
		public DbSet<Work> Works { get; set; }
		public DbSet<GarageOrder> Orders { get; set; }
		public DbSet<Mechanic> Mechanics { get; set; }
		public DbSet<OrderPosition> OrderPositions { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<CarModel> CarModels { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<ClientCar> ClientCars { get; set; }

		public Context() : base() {
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		public Context(DbContextOptions<Context> options) : base(options) {
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var rel in modelBuilder.Model
				.GetEntityTypes()
				.Where(e => !e.IsOwned())
				.SelectMany(e => e.GetForeignKeys()))
			{
				rel.DeleteBehavior = DeleteBehavior.Restrict;
			}

			base.OnModelCreating(modelBuilder);
		}
	}
}
