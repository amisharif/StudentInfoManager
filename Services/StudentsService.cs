using AutoMapper;
using Entities;
using Newtonsoft.Json;
using ServiceStudents;
using ServiceStudents.DTO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Services
{
    public class StudentsService : IStudentsSercice
    {
        public readonly StudentDbContext _context;
        private readonly IMapper _mapper;


        private readonly string url = "https://localhost:7103/api/StudentAPIController/";
        private readonly HttpClient client = new HttpClient();


        public StudentsService(StudentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }

            return students;
        }

        public StudentResponse GetStudentByID(int ID)
        {

            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url+ID).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }

            return student.ToStudentResponse();

        }


        public StudentResponse AddStudent(StudentAddRequest studentAddRequest)
        {
            Student student = studentAddRequest.ToStudent();
            student.StartDate = DateTime.Now;
            
            //_context.Students.Add(student);
            //_context.SaveChanges();
            StudentResponse studentResponse = _mapper.Map<StudentResponse>(student);

            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url,content).Result;

            if (response.IsSuccessStatusCode)
            {
                return studentResponse;
            }
            

            return null;
           // return student.ToStudentResponse();
        }

        public StudentResponse UpdateStudent(int ID, StudentUpdateRequest studentUpdateRequest)
        {
            Student student = studentUpdateRequest.ToStudent();
            //_context.Students.Update(student);
            //_context.SaveChanges();
            // StudentResponse studentResponse = student.ToStudentResponse();

            StudentResponse studentResponse = _mapper.Map<StudentResponse>(student);

            string data = JsonConvert.SerializeObject(student);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+ID, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return studentResponse;
            }

            return null;
        }

        public bool DeleteStudent(int ID)
        {
           
          
            HttpResponseMessage response = client.DeleteAsync(url + ID).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }


      
    }
}
