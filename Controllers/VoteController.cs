using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using STUDENTEVOTINGAPP.DTOs.VoteDto;
using STUDENTEVOTINGAPP.Interfaces.Repositories;

namespace STUDENTEVOTINGAPP.Controllers
{
    public class VoteController : Controller
    {
        public IVoteService _voteService;
        public ICandidateService _candidateService;
        public IPositionService _positionService;
        public IElectionService _electionService;

        public VoteController(IVoteService voteService, ICandidateService candidateService, IPositionService positionService, IElectionService electionService)
        {
            _voteService = voteService;
            _candidateService = candidateService;
            _positionService = positionService;
            _electionService = electionService;
        }

        public IActionResult Index()
        {
            var votes = _voteService.GetVotes();
            return View(votes.Data);
        }
        public IActionResult CastVote()
        {
            var elections = _electionService.GetElections();
            ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
            var positions = _positionService.GetPositions();
            ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");
            var candidates = _candidateService.GetAllCandidates();
            ViewData["Candidates"] = new SelectList(candidates.Data, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public IActionResult CastVote(VoteRequestModel request)
        {
            var voterRegId = HttpContext.Session.GetString("VoterRegID");
            var isSuccessful = _voteService.CastVote(voterRegId, request);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetVotesByPositionId()
        {
            var elections = _electionService.GetElections();
            ViewData["Elections"] = new SelectList(elections.Data, "Id", "Name");
            var positions = _positionService.GetPositions();
            ViewData["Positions"] = new SelectList(positions.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult GetVotesByPositionId(VoteRequestModel request)
        {
            var isSuccessful = _voteService.GetVotesByPositionId(request.ElectionId, request.PositionId);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return View("GetVotesByPositionIdView", isSuccessful.Data);
        }
        public IActionResult GetVotesByPositionIdView()
        {
            return View();
        }
        public IActionResult GetVotesByCandidateId()
        {
            var candidates = _candidateService.GetAllCandidates();
            ViewData["Candidates"] = new SelectList(candidates.Data, "ID", "FullName");
            return View();
        }
        [HttpPost]
        public IActionResult GetVotesByCandidateId(VoteRequestModel request)
        {
            var isSuccessful = _voteService.GetVotesByCandidateId(request.CandidateId);
            if (isSuccessful.Status == false)
            {
                ViewBag.Message = isSuccessful.Message;
                return View();
            }
            return View("GetVotesByCandidateIdView", isSuccessful.Data);
        }
        public IActionResult GetVotesByCandidateIdView()
        {
            return View();
        }
    }
}
