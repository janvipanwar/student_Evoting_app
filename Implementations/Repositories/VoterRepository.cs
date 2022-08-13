
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class VoterRepository : IVoterRepository
    {
        private readonly ApplicationContext _context;

        public VoterRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Voter CreateVoter(Voter voter)
        {
            _context.Voters.Add(voter);
            _context.SaveChanges();
            return voter;
        }

        public bool DeleteVoter(Voter voter)
        {
            _context.Voters.Remove(voter);
            _context.SaveChanges();
            return true;
        }


        public Voter GetVoter(int id)
        {
            var voter = _context.Voters.Find(id);
            if (voter == null)
            {
                return null;
            }
            else
            {
                return voter;
            }
        }

        public IList<Voter> GetVoters()
        {
            return _context.Voters.ToList();
        }

        public bool IsAdmin(UserRole userRole)
        {
            var isAdmin = userRole == UserRole.Admin || userRole == UserRole.SuperAdmin;
            return isAdmin;
        }

        public bool VoterExist(string matricnumber)
        {
            return _context.Voters.Any(vot => vot.MatricNumber == matricnumber);
        }
    }
}
