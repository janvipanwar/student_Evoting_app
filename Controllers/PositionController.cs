using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using STUDENTEVOTINGAPP.DTOs.PositionDto;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class PositionController : Controller
    {
        public IPositionService _positionService;
        public IPositionRepository _positionRepository;
        public IElectionService _electionService;

        public PositionController(IPositionService positionService, IElectionService electionService, IPositionRepository positionRepository)
        {
            _positionService = positionService;
            _electionService = electionService;
            _positionRepository = positionRepository;
        }

        public IActionResult Index()
        {
            var positions = _positionService.GetPositions();
            if (positions.Data == null || positions.Status == false)
            {
                ViewBag.Message = positions.Message;
                return RedirectToAction("Index", "Admin");
            }
            return View(positions.Data);
        }
        public IActionResult Create()
        {
            var elections = _electionService.GetElections();
            ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(PositionDto dto)
        {
            var isSuccessful = _positionService.CreatePosition(dto);
            if (isSuccessful.Data == null || isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult GetPositionsByElectionId(int ElectionId)
        {
            var candidate = _positionService.GetPositionsByElectionId(ElectionId);
            if (candidate == null)
            {
                return NotFound($"Candidate with ID {ElectionId} does not Exist");
            }
            return View(candidate.Data);
        }

        public IActionResult Delete(int id)
        {
            var position = _positionRepository.GetPosition(id);
            if (position == null)
            {
                return NotFound($"Candidate does not Exist");
            }
            return View(position);
        }
        [HttpPost]
        public IActionResult Deletes(int id)
        {
            var isDeleted = _positionService.DeletePosition(id);
            if (isDeleted.Status == false)
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Edit(int id)
        {
            var position = _positionRepository.GetPosition(id);
            if (position == null)
            {
                return NotFound($"Position with ID {id} does not Exist");
            }
            return View(position);
        }
        [HttpPost]
        public IActionResult Edit(PositionDto position, int id)
        {
            _positionService.EditPosition(position, id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
