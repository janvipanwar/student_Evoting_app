using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using STUDENTEVOTINGAPP.DTOs.CandidateDto;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class CandidateController : Controller
    {
        public ICandidateService _candidateService;
        public IPositionService _positionService;
        public IElectionService _electionService;
        public CandidateController(ICandidateService candidateService, IPositionService positionService, IElectionService electionService)
        {
            _candidateService = candidateService;
            _positionService = positionService;
            _electionService = electionService;
        }

        public IActionResult Index()
        {
            var candidates = _candidateService.GetAllCandidates();
            return View(candidates.Data);
        }
        public IActionResult Create()
        {
            var elections = _electionService.GetElections();
            ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
            var positions = _positionService.GetPositions();
            ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCandidateRequestModel request)
        {
            var matricNo = HttpContext.Session.GetString("MatricNumber");
            var isSuccessful = _candidateService.RegisterCandidate(matricNo, request);
            if (isSuccessful.Data == null || isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("VoterPage", "Voter");
        }


        public IActionResult Edit(CreateCandidateRequestModel request)
        {
            var matricNumber = HttpContext.Session.GetString("MatricNumber");
            var candidate = _candidateService.GetCandidateByMatricNumber(matricNumber);
            if (candidate == null)
            {
                return NotFound($"Position with MatricNumber {matricNumber} does not Exist");
            }
            var positions = _positionService.GetPositions();
            ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");
            return View(request);
        }

        [HttpPost]
        public IActionResult Edits(CreateCandidateRequestModel request)
        {
            var matricNo = HttpContext.Session.GetString("MatricNumber");
            var isSuccessful = _candidateService.UpdateCandidate(matricNo, request);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("VoterPage", "Voter");
        }
        public IActionResult GetCandidatesByPositionId(int PositionId)
        {
            var candidate = _candidateService.GetCandidatesByPositionId(PositionId);
            if (candidate == null)
            {
                return NotFound($"Candidate with ID {PositionId} does not Exist");
            }
            return View(candidate.Data);
        }
        public IActionResult GetCandidatesByElectionAndPositionIds(int PositionId, int ElectiontionId)
        {
            var candidate = _candidateService.GetCandidatesByElectionAndPositionIds(ElectiontionId, PositionId);
            if (candidate == null)
            {
                return NotFound($"Candidate does not Exist");
            }
            return View(candidate.Data);
        }
        public IActionResult Get(int id)
        {
            var candidate = _candidateService.GetCandidate(id);
            if (candidate == null)
            {
                return NotFound($"Candidate does not Exist");
            }
            return View(candidate.Data);
        }
       
        public IActionResult Delete(int id)
        {
            var candidate = _candidateService.GetCandidatesByPositionId(id);
            if (candidate == null)
            {
                return NotFound($"Candidate does not Exist");
            }
            return View(candidate);
        }
        [HttpPost]
        public IActionResult Deletes(int id)
        {
            var isDeleted = _candidateService.DeleteCandidate(id);
            if (isDeleted.Status == false)
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
