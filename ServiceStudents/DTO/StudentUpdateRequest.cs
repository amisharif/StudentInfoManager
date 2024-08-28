using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStudents.DTO
{
    public class StudentUpdateRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public DateTime StartDate { get; set; }

        public Student ToStudent()
        {
            return new Student { ID = ID, Name = Name, Dept = Dept };
        }
       
    }
}
