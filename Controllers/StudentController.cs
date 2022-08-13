using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class StudentController : Controller
    {
        public IStudentService _studentservice;

        public StudentController(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            var isSuccessful = _studentservice.RegisterStudents();
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Get()
        {
            var students = _studentservice.GetStudents();
            if (students == null)
            {
                return NotFound("No Student Registered Yet");
            }
            return View(students.Data);
        }
    }
}
