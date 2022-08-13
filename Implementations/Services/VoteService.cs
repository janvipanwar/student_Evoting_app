using Microsoft.AspNetCore.Http;
using STUDENTEVOTINGAPP.Context;
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
    public class VoteService : IVoteService
    {
        private readonly ApplicationContext _context;
        private readonly IVoteRepository _voteRepository;
         
        public VoteService(ApplicationContext context, IVoteRepository voteRepository)
        {
            _context = context;
            _voteRepository = voteRepository;
        }

        public BaseResponseModel CastVote(string voterRegId, VoteRequestModel voteRequest)
        {
            var getVoter = _context.Voters.SingleOrDefault(vot => vot.VoterRegId == voterRegId);
            var election = _context.Elections.Find(voteRequest.ElectionId);
            var verifyElectionDate = DateTime.Now >= election.ElectionOpenDate && DateTime.Now <= election.ElectionCloseDate;
            if (election == null)
            {
                return new BaseResponseModel
                {
                    Status = false,
                    Message = "Election Does Not Exist"
                };
            }
            if (verifyElectionDate == false)
            {
                return new BaseResponseModel
                {
                    Status = false,
                    Message = "Election is Yet commence or has closed"
                };
            }
            if (_context.Votes.Any(vot => vot.VoterId == voteRequest.VoterId && vot.PositionId == voteRequest.PositionId))
            {
                return new BaseResponseModel
                {
                    Status = false,
                    Message = "You have Voted Already for this position"
                };
            }
            var newVote = new Vote
            {
                VoterRegId = getVoter.VoterRegId,
                VoterId = getVoter.Id,
                ElectionId = voteRequest.ElectionId,
                CandidateId = voteRequest.CandidateId,
                PositionId = voteRequest.PositionId
            };
            _voteRepository.CastVote(newVote);
            return new BaseResponseModel
            {
                Status = true,
                Message = "Vote Successful"
            };
        }

        public VotesResponseModel GetVotes()
        {
            var votes = _voteRepository.GetVotes();
            if (votes == null)
            {
                return new VotesResponseModel
                {
                    Status = false,
                    Message = "No vote Available"
                };
            }
            return new VotesResponseModel
            {
                Data = votes.Select(vot => new VoteDto
                {
                    VoterId = vot.VoterId,
                    Id = vot.Id,
                    CandidateId = vot.CandidateId,
                    ElectionId = vot.ElectionId,
                    PositionId = vot.PositionId,
                    CandidateName = vot.Candidates.FullName,
                    ElectionName = vot.Election.Name,
                    PositionName = vot.Positions.Name,
                    VoteCount = _voteRepository.GetVotesByCandidateId(vot.CandidateId).Count(),
                    MatricNumber = vot.Candidates.MatricNum
                }).ToList(),
                Status = true,
                Message = "Votes Retrieved Successfully"
            };
        }

        public VotesResponseModel GetVotesByCandidateId(int CandidateId)
        {
            var votes = _voteRepository.GetVotesByCandidateId(CandidateId);
            if (votes == null)
            {
                return new VotesResponseModel
                {
                    Status = false,
                    Message = "No vote Available"
                };
            }
            return new VotesResponseModel
            {
                Data = votes.Select(vot => new VoteDto
                {
                    VoterId = vot.VoterId,
                    Id = vot.Id,
                    CandidateId = vot.CandidateId,
                    ElectionId = vot.ElectionId,
                    PositionId = vot.PositionId
                }).ToList(),
                Status = true,
                Message = "Votes Retrieved Successfully"
            };
        }

        public VotesResponseModel GetVotesByPositionId(int ElectionId, int PositionId)
        {
            var votes = _voteRepository.GetVotesByPositionId(ElectionId, PositionId);
            if (votes == null)
            {
                return new VotesResponseModel
                {
                    Status = false,
                    Message = "No vote Available"
                };
            }
            return new VotesResponseModel
            {
                Data = votes.Select(vot => new VoteDto
                {
                    VoterId = vot.VoterId,
                    Id = vot.Id,
                    CandidateId = vot.CandidateId,
                    ElectionId = vot.ElectionId,
                    PositionId = vot.PositionId
                }).ToList(),
                Status = true,
                Message = "Votes Retrieved Successfully"
            };
        }
    }
}
