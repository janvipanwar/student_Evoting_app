
using Microsoft.EntityFrameworkCore;
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ApplicationContext _context;

        public VoteRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool CastVote(Vote vote)
        {
            _context.Votes.Add(vote);
            _context.SaveChanges();
            return true;
        }

        public IList<Vote> GetVotes()
        {
            var query = _context.Votes.ToList();
            return query;
        }

        public IList<Vote> GetVotesByCandidateId(int CandidateId)
        {
            var query = _context.Votes.Where(d => d.CandidateId == CandidateId).Include(f => f.Voters).Include(b => b.Positions).ThenInclude(a => a.Candidates).ToList();
            return query;
        }

        public IList<Vote> GetVotesByPositionId(int ElectionId, int PositionId)
        {
            var query = _context.Votes.Where(d => d.ElectionId == ElectionId && d.PositionId == PositionId ).Include(f => f.Voters).Include(b => b.Positions).ThenInclude(a => a.Candidates).ThenInclude(a => a.Election).ToList();
            return query;
        }
    }
}
