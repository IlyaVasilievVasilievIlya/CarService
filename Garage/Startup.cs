using AutoMapper;

using Business.Repositories.DataRepositories;
using Business.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Repository.Data;
using Repository.Repositories;


namespace Garage
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IConfigurationRoot _configuration;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(_environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region common 
            services.AddSingleton<IConfiguration>(_configuration);

            services.AddDbContext<Context>(
                options => options
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Repository")),
                contextLifetime: ServiceLifetime.Singleton,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IWorkRepository, WorkRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IClientCarRepository, ClientCarRepository>();
            services.AddScoped<IMechanicRepository, MechanicRepository>();
            services.AddScoped<IOrderPositionRepository, OrderPositionRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            #endregion

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IMechanicService, MechanicService>();        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context db)
        {
            //db.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
