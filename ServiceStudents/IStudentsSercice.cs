using Entities;
using ServiceStudents.DTO;

namespace ServiceStudents
{
    public interface IStudentsSercice
    {
        public StudentResponse AddStudent( StudentAddRequest studentAddRequest);
        public StudentResponse GetStudentByID(int studentID);
        public List<Student> GetAllStudents();
        public StudentResponse UpdateStudent(int ID,StudentUpdateRequest studentUpdateRequest);
        public bool DeleteStudent(int ID);
      
    }
}
