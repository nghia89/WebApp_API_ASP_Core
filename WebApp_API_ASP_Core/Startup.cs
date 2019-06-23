﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data.EF.Entities;

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
			services.AddDbContext<DbContext>(Options => Options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);

			services.AddIdentity<AppUser,AppRole>(options => {
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;

			})
		   .AddEntityFrameworkStores<DbContext>()
		   .AddDefaultTokenProviders();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
