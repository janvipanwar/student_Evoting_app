using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.CandidateDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface ICandidateService
    {
        CandidateResponseModel RegisterCandidate(string matricNo, CreateCandidateRequestModel request);
        BaseResponseModel UpdateCandidate(string matricNo, CreateCandidateRequestModel request);
        BaseResponseModel DeleteCandidate(int id);
        CandidatesResponseModel GetCandidatesByPositionId(int Positionid);
        CandidateResponseModel GetCandidate(int id);
        CandidatesResponseModel GetCandidatesByElectionAndPositionIds(int electionId, int positionId);
        CandidatesResponseModel GetAllCandidates();
        CandidateResponseModel GetCandidateByMatricNumber(string MatricNumber);
    }
}
