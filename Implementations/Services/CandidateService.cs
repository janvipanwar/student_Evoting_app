
using Microsoft.AspNetCore.Http;
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
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IElectionRepository _electionRepository;

        public CandidateService(ICandidateRepository candidateRepository, IStudentRepository studentRepository, IElectionRepository electionRepository)
        {
            _candidateRepository = candidateRepository;
            _studentRepository = studentRepository;
            _electionRepository = electionRepository;
        }

        public BaseResponseModel DeleteCandidate(int id)
        {
            var candidate = _candidateRepository.GetCandidate(id);
            if (candidate == null)
            {
                return new BaseResponseModel
                {
                    Message = "Candidate Not Found",
                    Status = false
                };
            }
            else
            {
                _candidateRepository.DeleteCandidate(id);
                return new BaseResponseModel
                {
                    Message = "Candidate Deleted Successfully",
                    Status = true
                };
            }
        }

        public CandidatesResponseModel GetAllCandidates()
        {
            var candidates = _candidateRepository.GetAllCandidates();
            if (candidates == null)
            {
                return new CandidatesResponseModel
                {
                    Status = false,
                    Message = "Candidate Not Found",
                };
            }
            return new CandidatesResponseModel
            {
                Data = candidates,
                Status = true,
                Message = "Candidate Sucessfully retrieved",
            };
        }

        public CandidatesResponseModel GetCandidatesByPositionId(int Positionid)
        {
            var candidates = _candidateRepository.GetCandidatesByPositon(Positionid);
            if (candidates == null)
            {
                return new CandidatesResponseModel
                {
                    Status = false,
                    Message = "Candidate Not Found",
                };
            }
            return new CandidatesResponseModel
            {
                Data = candidates,
                Status = true,
                Message = "Candidate Sucessfully retrieved",
            };
        }
        public CandidateResponseModel GetCandidate(int id)
        {
            var candidate = _candidateRepository.GetCandidate(id);
            if (candidate == null)
            {
                return new CandidateResponseModel
                {
                    Status = false,
                    Message = "Candidate Not Found",
                };
            }
            return new CandidateResponseModel
            {
                Data = new CandidateDto
                {
                    ID = candidate.ID,
                    FullName = candidate.FullName,
                    MatricNum = candidate.MatricNum,
                    ElectionId = candidate.ElectionId,
                    PositionId = candidate.PositionId,
                    User = candidate.User,
                    PositionName = candidate.Positions.Name,
                    ElectionName = candidate.Election.Name
                },
                Status = true,
                Message = "Candidate Sucessfully retrieved",
            };
        }


        public CandidatesResponseModel GetCandidatesByElectionAndPositionIds(int electionId, int positionId)
        {
            var candidates = _candidateRepository.GetCandidatesByElectionAndPositionIds(electionId, positionId);
            if (candidates == null)
            {
                return new CandidatesResponseModel
                {
                    Status = false,
                    Message = "Candidate Not Found",
                };
            }
            return new CandidatesResponseModel
            {
                Data = candidates,
                Status = true,
                Message = "Candidate Sucessfully retrieved",
            };
        }

        public CandidateResponseModel RegisterCandidate(string matricNo, CreateCandidateRequestModel request)
        {
            var electionExist = _electionRepository.ElectionExistId(request.ElectionId);
            if (!electionExist)
            {
                return new CandidateResponseModel
                {
                    Status = false,
                    Message = $"{request.ElectionName} Not Found",
                };
            }
            var findElection = _electionRepository.GetElection(request.ElectionId);
            var registrationClosed = DateTime.Now < findElection.ElectionOpenDate;
            var alreadyRegistered = _candidateRepository.CandidateExist(matricNo, request.ElectionId);
            
            if (registrationClosed)
            {
                return new CandidateResponseModel
                {
                    Status = false,
                    Message = $"Registartion for {findElection.Name} has closed",
                };
            }
            if (alreadyRegistered)
            {
                return new CandidateResponseModel
                {
                    Status = false,
                    Message = $"Candidate Already Registered for a position in this Election",
                };
            }
            var GetCandidate = _studentRepository.GetStudentByMatricNumber(matricNo);
            var candidate = new Candidate
            {
                FullName = $"{GetCandidate.FirstName} {GetCandidate.LastName}",
                MatricNum = matricNo,
                User = Enums.UserRole.Candidates,
                 ElectionId = request.ElectionId,
                 PositionId = request.PositionId,
                 
            };
            _candidateRepository.CreateCandidate(candidate);
            return new CandidateResponseModel
            {
                Data = new CandidateDto
                {
                    FullName = candidate.FullName,
                    MatricNum = candidate.MatricNum,
                    ElectionId = candidate.ElectionId,
                    PositionId = candidate.PositionId,
                    User = candidate.User
                },
                Status = true,
                Message = "Candidate Registered Successfully",
            };
        }

        public BaseResponseModel UpdateCandidate(string matricNo, CreateCandidateRequestModel request)
        {
            var findCandidate = _candidateRepository.GetCandidateByMatricNumber(matricNo);
            if (findCandidate == null)
            {
                return new BaseResponseModel
                {
                    Message = "Candidate Not Found",
                    Status = false
                };
            }
            findCandidate.PositionId = request.PositionId;
            _candidateRepository.EditCandidate(findCandidate);
            return new BaseResponseModel
            {
                Status = true,
                Message = "Candidate details Succesfully Updated",
            };
        }

        public CandidateResponseModel GetCandidateByMatricNumber(string MatricNumber)
        {
            var candidate = _candidateRepository.GetCandidateByMatricNumber(MatricNumber);
            if (candidate == null)
            {
                return new CandidateResponseModel
                {
                    Status = false,
                    Message = "Candidate Not Found",
                };
            }
            return new CandidateResponseModel
            {
                Data = new CandidateDto
                {
                    ID = candidate.ID,
                    FullName = candidate.FullName,
                    MatricNum = candidate.MatricNum,
                    ElectionId = candidate.ElectionId,
                    PositionId = candidate.PositionId,
                    User = candidate.User,
                    PositionName = candidate.Positions.Name,
                    ElectionName = candidate.Election.Name
                },
                Status = true,
                Message = "Candidate Sucessfully retrieved",
            };
        }
    }
}
