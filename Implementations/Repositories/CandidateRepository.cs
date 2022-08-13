
using Microsoft.EntityFrameworkCore;
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.CandidateDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationContext _context;

        public CandidateRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool CandidateExist(string matricnumber, int electionId)
        {
            var alreadyRegistered = _context.Candidates.Any(can => can.MatricNum == matricnumber && can.ElectionId == electionId);

            return alreadyRegistered;
        }

        public Candidate CreateCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }
        public bool DeleteCandidate(int id)
        {
            var candidate = _context.Candidates.Find(id);
            _context.Candidates.Remove(candidate);
            _context.SaveChanges();
            return true;
        }


        public Candidate EditCandidate(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public IList<CandidateDto> GetCandidatesByPositon(int id)
        {
            var candidates = _context.Candidates.Include(c => c.Positions).Include(d => d.Election).Where(can => can.PositionId == id).Select(can =>
           new CandidateDto
           {
               ID = can.ID,
               FullName = can.FullName,
               MatricNum = can.MatricNum,
               PositionId = can.PositionId,
               ElectionId = can.ElectionId,
               
            }).ToList();
            return candidates;
        }
        public List<CandidateDto> GetCandidatesByElectionAndPositionIds(int electionId, int positionId)
        {
            var candidates = _context.Candidates.Include(c => c.Positions).Include(d => d.Election).Where(can => can.ElectionId == electionId && can.PositionId == positionId).Select(candidates =>
            new CandidateDto
            {
                ID = candidates.ID,-
                FullName = candidates.FullName,
                MatricNum = candidates.MatricNum,
                PositionId = candidates.PositionId,
                ElectionId = candidates.ElectionId,
            }).ToList();
            return candidates;
        }
        public Candidate GetCandidate(int id)
        {
            var candidate = _context.Candidates.Include(candidate => candidate.Positions).Include(can => can.Election).Where(candidate => candidate.ID == id).SingleOrDefault();
           return candidate;

        }
        public Candidate GetCandidateByMatricNumber(string MatricNumber)
        {
            var candidate = _context.Candidates.Include(candidate => candidate.Positions).Include(can => can.Election).Where(candidate => candidate.MatricNum == MatricNumber).SingleOrDefault();
           return candidate;
        }

        public IList<CandidateDto> GetAllCandidates()
        {
            var candidates = _context.Candidates.Include(c => c.Positions).Include(d => d.Election).Select(candidates =>
            new CandidateDto
            {
                ID = candidates.ID,
                FullName = candidates.FullName,
                MatricNum = candidates.MatricNum,
                PositionId = candidates.PositionId,
                ElectionId = candidates.ElectionId,
            }).ToList();
            return candidates;
        }
    }
}
