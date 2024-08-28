using Entities;
using ServiceStudents.DTO;

namespace ServiceStudents
{
    public interface IStudentsSercice
    {
        public StudentResponse AddStudent( StudentAddRequest studentAddRequest);
        public StudentResponse GetStudentByID(int studentID);
        public List<Student> GetAllStudents();
        public StudentResponse UpdateStudent(StudentUpdateRequest studentUpdateRequest);
        public StudentResponse DeleteStudent(int ID);
      
    }
}
