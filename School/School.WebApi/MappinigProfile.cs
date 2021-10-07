using AutoMapper;
using School.DomainObjects;
using School.DomainObjects.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApi
{
    public class MappinigProfile : Profile
    {
        public MappinigProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentDTOWithCouresesForGet>();
            CreateMap<Course, CourseDTOForGet>();
        }
    }
}
