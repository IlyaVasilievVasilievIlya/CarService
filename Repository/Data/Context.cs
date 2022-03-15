using Business.Entities;
using Microsoft.EntityFrameworkCore;

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

		public Context() : base() { }

		public Context(DbContextOptions<Context> options) : base(options) { }
	}
}
