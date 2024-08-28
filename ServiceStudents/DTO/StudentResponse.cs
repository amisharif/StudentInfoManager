using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStudents.DTO
{
    public class StudentResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Dept { get; set; }
        public DateTime StartDate { get; set; }


        public StudentUpdateRequest ToUpdateRequest()
        {
            return new StudentUpdateRequest()
            {
                ID = ID,
                Name = Name,
                Dept = Dept,
                StartDate = StartDate
            };
        }
    }

   

    public static class StudentExtension
    {
        public static StudentResponse ToStudentResponse(this Student student)
        {
            return new StudentResponse
            {
                ID = student.ID,
                Name = student.Name,
                Dept = student.Dept,
                StartDate = student.StartDate,
            };

        }
    }



}
