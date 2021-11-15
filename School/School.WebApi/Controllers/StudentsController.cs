using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.BussinessLogic.Exceptions;
using School.DomainObjects;
using School.DomainObjects.DataTransferObjects;
using School.Interfaces.BusinessLogic;
using School.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.WebApi.Controllers
{

    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private const string server_error = "Internal Server Error";

        private readonly IStudentLogic _logic;
        private readonly IMapper _mapper;

        public StudentsController(IStudentLogic logic, IMapper mapper)
        {
            _logic = logic;
            _mapper = mapper; 
        }

        [HttpGet]
        [Auth("professor")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Student> result = _logic.GetAll().ToList();
                var returnResult = _mapper.Map<IEnumerable<StudentDTOWithCouresesForGet>>(result);
                return Ok(returnResult);
            }
            catch (Exception ex)
            {
                //Log de la excepcion
                return StatusCode(500, server_error);
            }
        }
               
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student = _logic.Get(id);
                if (student == null)
                {
                    return NotFound(id); 
                }
                                
                return Ok(new
                {
                    Nombre = student.Name,
                    Apellido = student.LastName
                });
            }
            catch (Exception ex)
            {
                //Log de la excepcion
                return StatusCode(500, server_error);
            }
        }

        [HttpGet("{id}/courses")]
        public string StudentCourses(int id)
        {
            return $"Listamos todos los cursos a lo que el estudiante con Id {id} esta inscripto";
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO studentData)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    Student s = _mapper.Map<Student>(studentData);
                    _logic.Add(s);
                    return Ok();
                //}
                //return UnprocessableEntity(ModelState);
            }
            catch (ArgumentNullException nullex)
            {
                return BadRequest(nullex.Message);
            }
            catch (DuplicatedObjectException dupex)
            {
                //Un objeto duplicado de hecho, es un "conflicto". Semanticamente es mas correcto retornar http 409 (Conflict) que 400
                return Conflict(dupex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, server_error);
            }
        }
            
        [HttpPut()]
        public IActionResult Put([FromBody] StudentDTO studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Student s = _mapper.Map<Student>(studentData);
                    var studentToUpdate = _logic.Update(s);
                    if (studentToUpdate == null)
                    {
                        return NotFound(studentData.Id);
                    }
                    return Ok(studentToUpdate);
                }
                return UnprocessableEntity(ModelState);
            }
            catch(ArgumentNullException nullex)
            {
                //Nos enviaron un objeto invalido. Puntualmente en este caso esta bien devolver el mensaje de la exception porque
                //no revela detalles de implementacion.
                return BadRequest(nullex.Message);
            }
            catch (DuplicatedObjectException dupex)
            {
                //Retornamos lo mismo que antes y esta Ok, pero de hecho es un caso distinto y conviene manejarlo por separado
                return Conflict(dupex.Message);
            }
            catch (Exception ex)
            {
                //Si el error es cualquier otra cosa... retornamos un 500
                //En cualquier caso podriamos guardar log de la excepcion por ejemplo
                return StatusCode(500, server_error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var removed = _logic.Remove(id);
                if (removed)
                {
                    return Ok();
                }

                return NotFound(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, server_error);
            }
        }
    }
}
