using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_BLL.Interfaces;
using System.Threading;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using AutoMapper;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess;

namespace Binary_Project_Structure
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
            services.AddMvc();
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddTransient<ICrewService, CrewService>();
            services.AddTransient<IDepartureService, DepartureService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<IStewardessService, StewardessService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITypeAircraftService, TypeAircraftService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
