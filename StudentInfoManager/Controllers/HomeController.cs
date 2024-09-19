using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStudents;
using ServiceStudents.DTO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace StudentInfoManager.Controllers
{


   // [AllowAnonymous]
    public class HomeController : Controller
    {

        private readonly IStudentsSercice _studentsService;
        public HomeController(IStudentsSercice studentsSercice)
        {
            _studentsService = studentsSercice;
        }


        [Authorize]
       // [Authorize (Roles ="Admin")]
        public IActionResult Index()
        {
            List<Student> students = _studentsService.GetAllStudents();
            return View(students);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(StudentAddRequest studentAddRequest)
        {
            StudentResponse std = _studentsService.AddStudent(studentAddRequest);
            if(std !=null) return RedirectToAction("Index");
            return View();

        }

        [Authorize]
        public IActionResult Edit(int ID)
        {
            StudentResponse studentResponse = _studentsService.GetStudentByID(ID);

            StudentUpdateRequest studentUpdateRequest = studentResponse.ToUpdateRequest();
            return View(studentUpdateRequest);
        }

        [Authorize]
        public IActionResult Edit(int ID, StudentUpdateRequest studentUpdateRequest)
        {
           // Student std = studentUpdateRequest.ToStudent();

            StudentResponse student = _studentsService.UpdateStudent(ID,studentUpdateRequest);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int ID)
        {
           bool response = _studentsService.DeleteStudent(ID);
            if (response)
            {
                return RedirectToAction("Index");
            }return View();
           
        }


       




    }
}
