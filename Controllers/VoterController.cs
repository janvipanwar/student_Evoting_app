using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.VoteDto;
using STUDENTEVOTINGAPP.DTOs.VoterDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class VoterController : Controller
    {
        public IVoterService _voterService;
        private readonly ApplicationContext _context;

        public VoterController(IVoterService voterService, ApplicationContext context)
        {
            _voterService = voterService;
            _context = context;
        }
        public IActionResult Index()
        {
            var voters = _voterService.GetVoters();
            return View(voters.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateRequest request)
        {
            var isSuccessful = _voterService.AddVoter(request);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Voter");
            }
        }
        public IActionResult Get(int id)
        {
            var voter = _voterService.GetVoter(id);
            var ghj = voter.Data;
            if (voter == null)
            {
                return NotFound($"Candidate with ID {id} does not Exist");
            }
            return View(voter.Data);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(VoterDto dto)
        {
            var loginStatus = _voterService.VoterLogin(dto);
            if (loginStatus.Status == false)
            {
                ViewBag.Message = loginStatus.Message;
                return View();
            }
            else
            {
                HttpContext.Session.SetString("UserName", loginStatus.Data.FullName);
                HttpContext.Session.SetInt32("ID", loginStatus.Data.Id);
                HttpContext.Session.SetString("VoterRegID", loginStatus.Data.VoterRegId);
                HttpContext.Session.SetString("MatricNumber", loginStatus.Data.MatricNumber);
                return RedirectToAction("VoterPage");
            }
        }
        public IActionResult Delete(int id)
        {
            var voter = _voterService.GetVoter(id);
            if (voter == null)
            {
                return NotFound($"Admin does not Exist");
            }
            return View(voter);
        }
        [HttpPost]
        public IActionResult Delete(int id, Voter voter)
        {
            var isDeleted = _voterService.DeleteVoter(id);
            if (isDeleted == false)
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult VoterPage()
        {
            var id = HttpContext.Session.GetInt32("ID");
            if (id == null)
            {
               return RedirectToAction("Login");
            }
            return View();
        }
    }
}
