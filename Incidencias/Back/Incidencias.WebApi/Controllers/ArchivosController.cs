using AutoMapper;
using Incidencias.InterfacesAccesoDatos;
using Incidencias.Modelos;
using Incidencias.Modelos.Enum;
using Incidencias.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace Incidencias.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        private IIncidenciasRepositorio _incidenciasRepositorio;
        private readonly IProyectosRepositorio _proyectosRepositorio;
        private readonly ILogger<ArchivosController> _logger;
        private readonly IMapper _mapper;

        public ArchivosController(IIncidenciasRepositorio _incidenciasRepositorio, IProyectosRepositorio proyectosRepositorio, ILogger<ArchivosController> logger, IMapper mapper)
        {
            this._incidenciasRepositorio = _incidenciasRepositorio;
            this._proyectosRepositorio = proyectosRepositorio;
            this._logger = logger;
            this._mapper = mapper;
        }

        // POST: api/Archivos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IncidenciaVM>>> Post(ArchivosMV fileMV)
        {
            try
            {
                List<Incidencia> incidencias;
                switch (fileMV.Proveedor)
                {
                    case "Proveedor1":
                        incidencias = LecturaDelXml(fileMV.URL).Result.bugs;
                        break;
                    case "Proveedor2":
                        incidencias = LecturaDelTxt(fileMV.URL).Result.bugs;
                        break;
                    default:
                        incidencias = null;
                        return BadRequest();
                }

                foreach (var bug in incidencias)
                {
                    var incidenciaActual = await _incidenciasRepositorio.ObtenerNombreAsync(bug.Nombre);
                    if (incidenciaActual != null && incidenciaActual.ProyectoId == bug.ProyectoId)
                    {
                        bug.Id = incidenciaActual.Id;
                        await _incidenciasRepositorio.Actualizar(bug);
                    }
                    else
                    {
                        var nuevaIncidencia = await _incidenciasRepositorio.Agregar(bug);
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en {nameof(Post)}: " + ex.Message);
                return BadRequest();
            }

        }
        private async Task<(bool IsSuccess, List<Incidencia> bugs)> LecturaDelXml(string path)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var nombreProyecto = xmlDoc.SelectNodes("//Empresa1//Proyecto")[0].InnerText;
                XmlNodeList file = xmlDoc.SelectNodes("//Empresa1");

                var proyecto = await _proyectosRepositorio.ObtenerNombreAsync(nombreProyecto);                
                if (proyecto != null)
                {
                    List<Incidencia> incidencias = new List<Incidencia>();
                    foreach (XmlNode bugs in file)
                    {

                        foreach (XmlNode item in bugs.SelectSingleNode("Bugs"))
                        {
                            Incidencia bug = new Incidencia();
                            bug.Nombre = item.ChildNodes[1].InnerText;
                            bug.Descripcion = item.ChildNodes[2].InnerText;
                            bug.Version = float.Parse(item.ChildNodes[3].InnerText);
                            bug.EstatusIncidencia = castEstatus(item.ChildNodes[4].InnerText);
                            bug.ProyectoId = proyecto.Id;

                            incidencias.Add(bug);
                        }

                    }
                    return (true, incidencias);
                }
                return (false, null);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error " + ex.Message);
                return (false, null);
            }
        }

        private async Task<(bool IsSuccess, List<Incidencia> bugs)> LecturaDelTxt(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    List<Incidencia> incidencias = new List<Incidencia>();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();                        
                        
                        Proyecto proyecto = await _proyectosRepositorio.ObtenerNombreAsync(line.Substring(0, 29).Trim());

                        if (proyecto != null)
                        {
                            Incidencia bug = new Incidencia();
                            bug.Nombre = line.Substring(34, 93).Trim();
                            bug.Descripcion = line.Substring(94, 150).Trim();
                            bug.Version = float.Parse(line.Substring(243, 10).Trim());
                            bug.EstatusIncidencia = castEstatus(line.Substring(253, 6).Trim());
                            bug.ProyectoId = proyecto.Id;
                            incidencias.Add(bug);                            
                        }                       
                    }
                    return (true, incidencias);
                }


            }
            catch (Exception ex)
            {
                _logger.LogError($"Error " + ex.Message);
                return (false, null);
            }
        }

        private EstatusIncidencia castEstatus(string value)
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
