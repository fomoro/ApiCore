using Incidencias.AccesoDatos;
using Incidencias.AccesoDatos.Contratos;
using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Incidencias.WebApi.Services
{
    public class LectorDeArchivos : BackgroundService
    {
        private readonly ILogger<LectorDeArchivos> _logger;
        private readonly IHostingEnvironment _env;

        private readonly IServiceScopeFactory _scopeFactory;

        public LectorDeArchivos(ILogger<LectorDeArchivos> logger, IHostingEnvironment env, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _env = env;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var pathXML = Path.Combine(_env.ContentRootPath, @"Resources\Archivos", "data.xml");
                var pathTXT = Path.Combine(_env.ContentRootPath, @"Resources\Archivos", "data.txt");

                UsingXmlDocumentWithXPath(pathXML);
                _logger.LogInformation("LectorDeArchivos running at: {time}", DateTimeOffset.Now);
                await Task.Delay(300000, stoppingToken);
            }
        }

        private async void UsingXmlDocumentWithXPath(string path)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var nombreProyecto = xmlDoc.SelectNodes("//Empresa1//Proyecto")[0].InnerText;
                XmlNodeList file = xmlDoc.SelectNodes("//Empresa1");

                foreach (XmlNode bugs in file)
                {
                    Incidencia bug = new Incidencia();
                    foreach (XmlNode item in bugs.SelectSingleNode("Bugs"))
                    {
                        //bug.Id = Int16.Parse(item.ChildNodes[0].InnerText);
                        bug.Nombre = item.ChildNodes[1].InnerText;
                        bug.Descripcion = item.ChildNodes[2].InnerText;
                        bug.Version = float.Parse(item.ChildNodes[3].InnerText);
                        bug.EstatusIncidencia = castEstatus(item.ChildNodes[4].InnerText);

                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var contexto = scope.ServiceProvider.GetRequiredService<Contexto>();
                            var proyecto = contexto.Proyectos.Where(x => x.Nombre == nombreProyecto).ToList();
                            if (proyecto.Count != 0)
                            {
                                var _incidenciasRepositorio = scope.ServiceProvider.GetRequiredService<IIncidenciasRepositorio>();
                                try
                                {
                                    var incidencia = contexto.Incidencias.Where(x => x.Nombre == bug.Nombre).FirstOrDefault();                                    
                                    bug.ProyectoId = proyecto.FirstOrDefault().Id;

                                    if (incidencia == null)
                                    {
                                        await _incidenciasRepositorio.Agregar(bug);
                                    }
                                    else if(incidencia.ProyectoId == bug.ProyectoId)
                                    {
                                        var resultado = await _incidenciasRepositorio.Actualizar(bug);
                                    }

                                }
                                catch (Exception excepcion)
                                {
                                    _logger.LogError($"Error en actualizar bug: " + excepcion.Message);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error " + ex.Message);
            }
        }

        public EstatusIncidencia castEstatus(string value)
        {
            if (value == "Activo")
            {
                return (EstatusIncidencia)1;
            }
            else
            {
                return (EstatusIncidencia)0;
            }
        }

    }
}





