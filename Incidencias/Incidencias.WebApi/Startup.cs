using System;
using System.Text;
using Incidencias.AccesoDatos;
using Incidencias.AccesoDatos.Repositorios;
using Incidencias.Interfaces;
using Incidencias.Interfaces.AccesoDatos;
using Incidencias.Modelos;
using Incidencias.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Incidencias.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Incidencias.WebApi", Version = "v1" });
            });
            services.AddDbContext<Contexto>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Inyeccion de dependencias 
            services.AddScoped<IRepositorioGenerico<Perfil>, PerfilesRepositorio>();            
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

            services.AddScoped<IProyectosRepositorio, ProyectosRepositorio>();
            services.AddScoped<IIncidenciasRepositorio, IncidenciasRepositorio>();

            //services.AddHostedService<LectorDeArchivos>();
            #region JWT
            services.AddSingleton<TokenService>(); //es como si fuera una clase estatica
            //Accedemos a la sección JwtSettings del archivo appsettings.json
            var jwtSettings = Configuration.GetSection("JwtSettings");
            //Obtenemos la clave secreta guardada en JwtSettings:SecretKey
            string secretKey = jwtSettings.GetValue<string>("SecretKey");
            //Obtenemos el tiempo de vida en minutos del Jwt guardada en JwtSettings:MinutesToExpiration
            int minutes = jwtSettings.GetValue<int>("MinutesToExpiration");
            //Obtenemos el valor del emisor del token en JwtSettings:Issuer
            string issuer = jwtSettings.GetValue<string>("Issuer");
            //Obtenemos el valor de la audiencia a la que está destinado el Jwt en JwtSettings:Audience
            string audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(minutes)
                };
            });

            //politica de acceso permitiendo acceder desde cualquier origen 
            //metodo  o encabezados
            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        //.AllowCredentials()
                        .AllowAnyHeader();
                    });

            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incidencias.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            //app.UseAuthorization();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
