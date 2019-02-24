using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campaign.Companion.Communication.Client.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Campaign.Companion.Communication.Client.SignalR
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IISServerOptions>(options =>
			{
				options.AutomaticAuthentication = false;
			});

			services.AddCors(options => options.AddPolicy("CorsPolicy",
				builder =>
				{
					builder.AllowAnyMethod().AllowAnyHeader()
						   .WithOrigins("http://localhost:62557")
						   .AllowCredentials();
				}));

			services.AddSignalR();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSignalR(routes =>
			{
				routes.MapHub<UniverseHub>("/universe");
			});

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("");
			//});
		}
	}
}
