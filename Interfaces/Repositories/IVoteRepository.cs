using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IVoteRepository
    {
        bool CastVote(Vote vote);
        IList<Vote> GetVotesByPositionId(int ElectionId, int PositionId);
        IList<Vote> GetVotesByCandidateId(int CandidateId);
        IList<Vote> GetVotes();
    }
}
