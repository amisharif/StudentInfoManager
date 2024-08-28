using AutoMapper;
using Entities;
using ServiceStudents.DTO;

namespace StudentInfoManager.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,StudentResponse>().ReverseMap();
        }
    }
}
