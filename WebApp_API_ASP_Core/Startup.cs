using AutoMapper;
using Infrastructure.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Business.Implementation;
using WebApp.Business.interfaces;
using WebApp.Data.EF;
using WebApp.Data.EF.Entities;
using WebApp.Repository.Implementation;
using WebApp.Repository.interfaces;

namespace WebApp_API_ASP_Core
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var MySqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<DBContext>(Options =>
			Options.UseMySql(MySqlConnectionString),ServiceLifetime.Scoped);
			
			services.AddIdentity<AppUser,AppRole>(options => {
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;

			})
		   .AddEntityFrameworkStores<DBContext>()
		   .AddDefaultTokenProviders();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddAutoMapper(typeof(Startup));


			///add server
			services.AddTransient(typeof(IUnitOfWork),typeof(EFUnitOfWork));
			services.AddTransient(typeof(IRepository<>),typeof(EFRepository<>));

			//add business
			services.AddTransient<IProductBusiness,ProductBusiness>();

			//add repository
			services.AddTransient<IProductRepository,ProductRepository>();



			///

			//services.AddSingleton(Mapper.Configuration);
			//services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(),sp.GetService));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,IHostingEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
