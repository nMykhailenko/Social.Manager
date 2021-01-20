using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Social.Manager.BLL.Mappings;
using Social.Manager.BLL.PersonalInformations;
using Social.Manager.BLL.PersonalInformations.Contract;
using Social.Manager.DAL.Context;

namespace Social.Manager.API
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
            services.AddAutoMapper(typeof(SocialManagerMappingProfiles));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionString"], b => b.MigrationsAssembly("Social.Manager.DAL")));

            services.AddScoped<IPersonalInformationService, PersonalInformationService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
