using AutoMapper;
using Entities;
using ServiceStudents;
using ServiceStudents.DTO;
using System.Globalization;

namespace Services
{
    public class StudentsService : IStudentsSercice
    {
        public readonly StudentDbContext _context;
        private readonly IMapper _mapper;
        public StudentsService(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudentResponse AddStudent(StudentAddRequest studentAddRequest)
        {
            Student student = studentAddRequest.ToStudent();
            student.StartDate = DateTime.Now;
            
            _context.Students.Add(student);
            _context.SaveChanges();

            StudentResponse studentResponse = _mapper.Map<StudentResponse>(student);
            return studentResponse;
           // return student.ToStudentResponse();
        }

        public StudentResponse DeleteStudent(int ID)
        {
            Student student = _context.Students.Find(ID);
            StudentResponse studentResponse = student.ToStudentResponse();
            _context.Remove(student);
            _context.SaveChanges();
            return studentResponse;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public StudentResponse GetStudentByID(int studentID)
        {
          
            Student student = _context.Students.Find(studentID);
            StudentResponse response = _mapper.Map<StudentResponse>(student);

            return response;
           
        }


        public StudentResponse UpdateStudent(StudentUpdateRequest studentUpdateRequest)
        {
            Student student = studentUpdateRequest.ToStudent();
            _context.Students.Update(student);
            _context.SaveChanges( ); 

           // StudentResponse studentResponse = student.ToStudentResponse();
           StudentResponse studentResponse = _mapper.Map<StudentResponse>(student);
            return(studentResponse);


        }
    }
}
