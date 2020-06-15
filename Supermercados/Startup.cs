using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AvisoRepository.Data;
using AvisoServices.Services;
using AvisoRepository.Repository;
using EstadisticasServices.Services;
using UbicacionServices.Services;
using UbicacionRepository.Repository;
using SupermercadosRepository.Repository;
using SupermercadosServices.Services;
using FiltrosServices.Services;

namespace AvisoService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            services.AddDbContext<FoodLackContexto>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("ConexionTest")));

            services.AddControllers();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddScoped<IAvisoServices, AvisoServices.Services.AvisoServices>();
            services.AddScoped<IEstadisticasServices, EstadisticasServices.Services.EstadisticasServices>();
            services.AddScoped<IUbicacionServices, UbicacionServices.Services.UbicacionServices>();
            services.AddScoped<ISupermercadosServices, SupermercadosServices.Services.SupermercadosServices>();
            services.AddScoped<IFiltrosServices, FiltrosServices.Services.FiltrosServices>();

            services.AddScoped<IAvisoRepository, AvisoRepository.Repository.AvisoRepository>();
            services.AddScoped<IUbicacionRepository, UbicacionRepository.Repository.UbicacionRepository>();
            services.AddScoped<ISupermercadosRepository, SupermercadosRepository.Repository.SupermercadosRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
           
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
            app.UseCors(
            options => options.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
