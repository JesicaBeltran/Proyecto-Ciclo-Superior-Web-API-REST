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
using Supermercados.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AvisoService
{
    public class Startup
    {
        //readonly string AllowSpecificOrigin = "_allowSpecificOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            services.AddDbContext<AvisoContexto>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("ConexionTest")));

            services.AddControllers();
            //nuevo 
            /*var key = "this is my test key";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });*/
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddCors();

            services.AddScoped<IAvisoServices, AvisoServices.Services.AvisoServices>();
            services.AddScoped<IAvisoRepository, AvisoRepository.Repository.AvisoRepository>();
           // services.AddSingleton<IAuthentication>(new Authentication(key));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            //nuevo:
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseCors(
        options => options.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyHeader()
    );
            app.UseMvc();
           

        }
    }
}
