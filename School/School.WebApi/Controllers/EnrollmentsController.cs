using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.DomainObjects.DataTransferObjects;
using School.Interfaces;
using School.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;
        private readonly IMapper _mapper;

        public EnrollmentsController(IStudentLogic logic, IMapper mapper)
        {
            //TODO: Noten que decidi  asignar a los estudiantes la responsabilidad de inscribirse a un curso, por lo tanto esa operacion
            //la defini en StudentLogic. Podria haberlo hecho en CoursesLogic (no existe aun) o directamente en un servicio especialmente creado 
            //para eso, "EnrollmentsLogic". Por lo tanto, en un controller puedo de hecho inyectar las dependencias que necesite, no tiene que ser
            //limitado a un objeto de logica de negocios por cada controller necesariamente en todos los casos, ni tampoco cada controller necesariamente
            //debe estar mapeado siempre a un objeto de logica de negocios.
            _studentLogic = logic;
            _mapper = mapper;
        }


        //// GET: api/<EnrollmentsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<EnrollmentsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// Inscripcion de un alumno a un curso.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] EnrollmentDTOForPost enrollment)
        {
            //Omitimos el manejo de excepciones a proposito

            if (ModelState.IsValid) // Valido los datos que me llegan (Notar que la fecha no es oblitatoria)
            {
                var enrollmentResult = _studentLogic.EnrollToCourse(enrollment.StudentId, enrollment.CourseId);

                if (enrollmentResult.Success)
                {
                    return Ok("Inscripcion realizada con exito");
                }

                //Es un escenario simplificado. Los errores podrian ser: El estudiante no existe, el curso no existe, el estudiante ya esta inscripto.
                return Conflict(enrollmentResult.Message);
            }
            return UnprocessableEntity(ModelState);
        }

        //// PUT api/<EnrollmentsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EnrollmentsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
