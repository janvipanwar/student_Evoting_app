using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.VoteDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IVoteService
    {
        BaseResponseModel CastVote(string VoterRegId, VoteRequestModel voteRequest);
        VotesResponseModel GetVotesByPositionId(int ElectionId, int PositionId);
        VotesResponseModel GetVotesByCandidateId(int CandidateId);
        VotesResponseModel GetVotes();
    }
}
