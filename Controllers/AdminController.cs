using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Interfaces.Repositories;
using STUDENTEVOTINGAPP.Models;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ApplicationContext _context;

        public AdminController(IAdminService adminService, ApplicationContext context)
        {
            _adminService = adminService;
            _context = context;
        }
        
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("ID");
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            var admins = _adminService.GetAdmins();
            return View(admins.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminRequestModel request)
        {
            var isSuccessful = _adminService.RegisterAdmin(request);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Get(int id)
        {
            var admin = _adminService.GetAdmin(id);
            if (admin == null)
            {
                return NotFound($"Candidate with ID {id} does not Exist");
            }
            return View(admin.Data);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Login(AdminRequestModel request)
        {
            var loginStatus = _adminService.AminLogin(request);
            if (loginStatus.Data == null)
            {
                ViewBag.Message = loginStatus.Message;
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("ID", loginStatus.Data.ID);
                HttpContext.Session.SetString("Name", loginStatus.Data.FullName);

                return RedirectToAction("Index");
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Delete(int id)
        {
            var admin = _adminService.GetAdmin(id);
            if (admin == null)
            {
                return NotFound($"Admin does not Exist");
            }
            return View(admin);
        }
        [HttpPost]
        public IActionResult Delete(int id, Admin admin)
        {
           var isDeleted = _adminService.DeleteAdmin(id);
            if (isDeleted.Status == false)
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Index");
        }
    }
}
