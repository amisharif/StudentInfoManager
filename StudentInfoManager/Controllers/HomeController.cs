using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceStudents;
using ServiceStudents.DTO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace StudentInfoManager.Controllers
{

    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly IStudentsSercice _studentsService;
        public HomeController(IStudentsSercice studentsSercice)
        {
            _studentsService = studentsSercice;
        }

        [Route("/")]
        [Route("[action]")]
        public IActionResult Index()
        {
            List<Student> students = _studentsService.GetAllStudents();
            return View(students);
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(StudentAddRequest studentAddRequest)
        {
            StudentResponse std = _studentsService.AddStudent(studentAddRequest);
            return RedirectToAction("Index");

        }



        [HttpGet]
        [Route("[action]/{ID}")]
        public IActionResult Edit(int ID)
        {
            StudentResponse studentResponse = _studentsService.GetStudentByID(ID);

            StudentUpdateRequest studentUpdateRequest = studentResponse.ToUpdateRequest();
            return View(studentUpdateRequest);
        }


        [HttpPost]
        [Route("[action]/{ID}")]
        public IActionResult Edit(StudentUpdateRequest studentUpdateRequest)
        {

            StudentResponse student = _studentsService.UpdateStudent(studentUpdateRequest);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("[action]/{ID}")]
        public IActionResult Delete(int ID)
        {
           StudentResponse student = _studentsService.DeleteStudent(ID);
           return RedirectToAction("Index");
        }





    }
}
