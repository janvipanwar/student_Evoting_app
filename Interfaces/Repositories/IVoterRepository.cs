using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IVoterRepository
    {
        Voter CreateVoter(Voter voter);
        bool DeleteVoter(Voter voter);
        bool IsAdmin(UserRole userRole);
        Voter GetVoter(int id);
        IList<Voter> GetVoters();
        bool VoterExist(string matricnumber);
    }
}
