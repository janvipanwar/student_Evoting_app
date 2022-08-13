using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.DTOs.ElectionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class ElectionController : Controller
    {
        public IElectionService _electionService;

        public ElectionController(IElectionService electionService)
        {
            _electionService = electionService;
        }

        public IActionResult Index()
        {
            var elctions = _electionService.GetElections();
            return View(elctions.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ElectionDto dto)
        {
            var isSuccessful = _electionService.CreateElection(dto);
            if (isSuccessful.Data == null || isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Get(int id)
        {
            var election = _electionService.GetElection(id);
            if (election == null)
            {
                return NotFound($"Election with ID {id} does not Exist");
            }
            return View(election.Data);
        }
        public IActionResult Edit(int id)
        {
            var election = _electionService.GetElection(id);
            if (election == null)
            {
                return NotFound($"Position with ID {id} does not Exist");
            }
            return View(election.Data);
        }
        [HttpPost]
        public IActionResult Edit(ElectionDto election, int id)
        {
            _electionService.EditElection(election, id);
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var election = _electionService.GetElection(id);
            if (election == null)
            {
                return NotFound($"Election does not Exist");
            }
            return View(election.Data);
        }
        [HttpPost]
        public IActionResult Delete(int id, Election election)
        {
            var isDeleted = _electionService.DeleteElection(id);
            if (isDeleted.Status == false)
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
