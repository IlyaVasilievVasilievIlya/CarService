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

			ConfigureSchema(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}


		private void ConfigureSchema(ModelBuilder modelBuilder)
		{
			var carModels = new CarModel[]
			{
				new CarModel {Id = 1, Name = "Toyota"},
				new CarModel {Id = 2, Name = "Honda"},
				new CarModel {Id = 3, Name = "Skoda"},
				new CarModel {Id = 4, Name = "Renault"}
			};
			modelBuilder.Entity<CarModel>().HasData(carModels);

			var cars = new Car[]
			{
				new Car { Id = 1, ModelId = 1, ManufactureYear = 1999},
				new Car { Id = 2, ModelId = 2, ManufactureYear = 2002},
				new Car { Id = 3, ModelId = 3, ManufactureYear = 2012}
			};
			modelBuilder.Entity<Car>().HasData(cars);

			var clients = new Client[]
				{
					new Client { Id = 1, FullName = "Петров И.А.", Email = "test1@text.com", PhoneNumber = "111-111-11-11" },
					new Client { Id = 2, FullName = "Сидоров Г.Г.", Email = "test2@text.com", PhoneNumber = "222-222-22-22"},
					new Client { Id = 3, FullName = "Демидов А.А.", Email = "test3@text.com", PhoneNumber = "333-333-33-33"}
				};
			modelBuilder.Entity<Client>().HasData(clients);

			var clientCars = new ClientCar[]
				{
					new ClientCar { Id = 1, ClientId = 1, CarId = 1},
					new ClientCar { Id = 2, ClientId = 2, CarId = 2},
					new ClientCar { Id = 3, ClientId = 3, CarId = 3}
				};
			modelBuilder.Entity<ClientCar>().HasData(clientCars);

			var garageOrders = new GarageOrder[]
				{
					new GarageOrder { Id = 1, ClientCarId = 1},
					new GarageOrder { Id = 2, ClientCarId = 2}
				};
			modelBuilder.Entity<GarageOrder>().HasData(garageOrders);


			var mechanics = new Mechanic[]
				{
					new Mechanic { Id = 1, Name = "Николаев И.И.", BirthDate = System.DateTime.Now, Email = "mec1@test4.com",PhoneNumber = "555-555-55-55"},
					new Mechanic { Id = 2, Name = "Ильин Г.А.", BirthDate = System.DateTime.Now, Email = "mec2@test5.com",PhoneNumber = "666-555-55-55"},
					new Mechanic { Id = 3, Name = "Дмитриев А.А.", BirthDate = System.DateTime.Now, Email = "mec3@test6.com",PhoneNumber = "666-777-55-55"}
				};
			modelBuilder.Entity<Mechanic>().HasData(mechanics);

			var statuses = new OrderPosition[]
				{
					new OrderPosition { Id = 1, OrderId = 1, MechanicId = 3, WorkId = 1, Count = 3},
					new OrderPosition { Id = 2, OrderId = 2, MechanicId = 2, WorkId = 2, Count = 1}
				};
			modelBuilder.Entity<OrderPosition>().HasData(statuses);

			var workTypes = new WorkType[]
				{
					new WorkType { Id = 1, Name = "Одностворчатое"},
					new WorkType { Id = 2, Name = "Двухстворчатое"},
					new WorkType { Id = 3, Name = "Трехстворчатое"},
					new WorkType { Id = 4, Name = "Развал-схождение"}
				};
			modelBuilder.Entity<WorkType>().HasData(workTypes);

			var works = new Work[]
				{
					new Work {Id = 1, Name="Замена", WorkTypeId=1, Price = 1000, Description ="DFD", Duration = new System.TimeSpan(2, 14, 18)},
					new Work {Id = 2, Name="Починка", WorkTypeId=2, Price = 1500, Description ="DFD", Duration = new System.TimeSpan(2, 14, 18)},
					new Work {Id = 3, Name="Восстановление", WorkTypeId=3, Price = 1400, Description ="DFD", Duration = new System.TimeSpan(2, 14, 18)}
				};

			modelBuilder.Entity<Work>().HasData(works);

		}
	}


}
