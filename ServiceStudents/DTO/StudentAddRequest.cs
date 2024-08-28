using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStudents.DTO
{
    public class StudentAddRequest
    {
        public string? Name { get; set; }
        public String? Dept { get; set; }

        public Student ToStudent()
        {
            return new Student { Name = Name, Dept = Dept };
        }
    }
}
