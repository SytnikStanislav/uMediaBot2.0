using AutoMapper;
using uMediaBotAPI.DAL;
using uMediaBotAPI.DAL.Data;
using uMediaBotAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uMediaBotAPI.DAL.Profiles;

namespace uMediaBotAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureAutoMapper(services);
            services.AddDbContext<MediaBotDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("uMediaBotAPI.DAL")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private IServiceCollection ConfigureAutoMapper(IServiceCollection services)
        {
            //TODO: ADD PROFILES
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<FolderProfile>();
            });

            return services;
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
