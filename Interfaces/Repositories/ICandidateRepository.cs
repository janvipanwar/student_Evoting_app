using STUDENTEVOTINGAPP.DTOs.CandidateDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        bool CandidateExist(string matricnumber, int electionId);
        Candidate CreateCandidate(Candidate candidate);
        bool DeleteCandidate(int id);
        Candidate EditCandidate(Candidate candidate);
        IList<CandidateDto> GetCandidatesByPositon(int id);
        List<CandidateDto> GetCandidatesByElectionAndPositionIds(int electionId, int positionId);
        Candidate GetCandidate(int id);
        Candidate GetCandidateByMatricNumber(string MatricNumber);
        IList<CandidateDto> GetAllCandidates();
        
    }
}
