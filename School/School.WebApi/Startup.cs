
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using School.BussinessLogic;
using School.DataAccess;
using School.DataAccess.Repositories;
using School.Interfaces;
using School.Interfaces.BusinessLogic;
using School.Interfaces.DataAccess;

namespace School.WebApi
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
            // GM: Así viene el código que se me genera automáticamente al crear un proyecto Web Api en .NET CORE
            // services.AddControllers();

            //GM: Así lo modifiqué para poder trabajar con "content negotiation", haciendo que me retorne XML en vez 
            //de JSON, según se lo especifico en el header "Accept" al hacer la llamada como vimos en clase.
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
            }).AddXmlDataContractSerializerFormatters();


            //Inyeccion de dependencia de objetos de logica de negocios
            services.AddScoped<IStudentLogic, StudentLogic>();

            services.AddScoped<IAuth, AuthLogic>();


             services.AddDbContext<MyDBContext>(opts =>
             opts.UseSqlServer(Configuration.GetConnectionString("sqlConnection"), //Leo el conection string llamado "sqlConnection" desde appsettings.json 
             b => b.MigrationsAssembly("School.WebApi"))); //Especifico el nombre del ensamblado donde quiero guardar las migraciones.

            //Inyeccion de dependencias de repositorio
            services.AddScoped<IRepositoryManager, RepositoryManager>();
                        
            //TODO: Inyeccion de dependencias de Automapper
            services.AddAutoMapper(typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "School.WebApi v1"));
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
