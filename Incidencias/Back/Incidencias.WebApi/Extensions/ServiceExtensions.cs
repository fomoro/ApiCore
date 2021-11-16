using Incidencias.InterfacesLogicaDeNegocio;
using Incidencias.LogicaDeNegocio;
using Incidencias.Modelos;
using Incidencias.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Incidencias.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        #region Implementación de CORS
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    //.AllowCredentials()
                    //builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });

            });
        }
        #endregion

        #region Implementación del JWT
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //Accedemos a la sección JwtSettings del archivo appsettings.json
            var jwtSettings = configuration.GetSection("JwtSettings");
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
        }
        #endregion

        #region Implementación de las dependencias
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPerfilesLogica, LogicaDePerfil>();
            services.AddScoped<IUsuariosLogica, LogicaDeUsuario>();
            services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
            services.AddScoped<IProyectosLogica, LogicaDeProyectos>();
            services.AddScoped<IIncidenciasLogica, LogicaDeIncidencia>();

            /*services.AddScoped<IRepositorioGenerico<Perfil>, PerfilesRepositorio>();
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
            services.AddScoped<IProyectosRepositorio, ProyectosRepositorio>();
            services.AddScoped<IIncidenciasRepositorio, IncidenciasRepositorio>();*/


            services.AddSingleton<TokenService>();
        }
        #endregion
    }
}
