
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.DTOs.VoteDto;
using STUDENTEVOTINGAPP.DTOs.VoterDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class VoterService : IVoterService
    {
        private readonly ApplicationContext _context;
        public IVoterRepository _voterRepository;
        public IStudentRepository _studentRepository;

        public VoterService(IVoterRepository voterRepository, IStudentRepository studentRepository, ApplicationContext context)
        {
            _voterRepository = voterRepository;
            _studentRepository = studentRepository;
            _context = context;
        }

        public BaseResponseModel AddVoter(CreateRequest request )
        {
            var isStudent = _studentRepository.GetStudentByMatricNumber(request.MatricNumber);
            if (isStudent == null)
            {
                return new BaseResponseModel
                {
                    Status = false,
                    Message = "Student Not Found",
                };
            }
            else
            {
                var voterExist = _voterRepository.VoterExist(isStudent.MatricNumber);
                var isAdmin = _voterRepository.IsAdmin(isStudent.UserRole);
                if (voterExist)
                {
                    return new BaseResponseModel
                    {
                        Status = false,
                        Message = "Voter Already Exist",
                    };
                }
                if (isAdmin)
                {
                    return new BaseResponseModel
                    {
                        Status = false,
                        Message = "Admins are not allowed to register",
                    };
                }
                var newVoter = new Voter
                {
                    FirstName = isStudent.FirstName,
                    LastName = isStudent.LastName,
                    PhoneNUmber = isStudent.PhoneNUmber,
                    EmailAddress = isStudent.EmailAddress,
                    Gender = isStudent.Gender,
                    MatricNumber = isStudent.MatricNumber,
                    Password = isStudent.Password,
                    UserRole = UserRole.Voter,
                    VoterRegId = $"STV{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                    
                };
                _voterRepository.CreateVoter(newVoter);
                return new BaseResponseModel
                {
                    Status = true,
                    Message = "Voter Sucessfully Created",
                };
            }
        }

        public bool DeleteVoter(int Id)
        {
           var voter = _voterRepository.GetVoter(Id);
            if (voter == null)
            {
                return false;
            }
            _voterRepository.DeleteVoter(voter);
            return true;
        }

        public VoterResponseModel GetVoter(int id)
        {
            var voter = _voterRepository.GetVoter(id);
            if (voter == null)
            {
                return new VoterResponseModel
                {
                    Message = "Voter Not Found",
                    Status = false,
                };
            }
            else
            {
                return new VoterResponseModel
                {
                    Data = new VoterDto 
                    { 
                        FullName = $"{voter.FirstName} {voter.LastName}",
                        MatricNumber = voter.MatricNumber,
                        Gender = voter.Gender,
                        Password = voter.Password,
                        UserRole = voter.UserRole,
                        VoterRegId = voter.VoterRegId,
                        Id = voter.Id,
                    },
                    Message = "Voter Successfully Retrieved",
                    Status = true
                };
            }
        }

        public VotersResponseModel GetVoters()
        {
            var voters = _voterRepository.GetVoters();
            if (voters == null)
            {
                return new VotersResponseModel
                {
                    Message = "Candidates not Found",
                    Status = false
                };
            }
            else
            {
                return new VotersResponseModel
                {
                    Data = voters, 
                    Message = "Candidates Successfully Retrieved",
                    Status = true
                };
            }
        }
        public VoterResponseModel VoterLogin(VoterDto dto)
        {
            var FindVoter= _context.Voters.Where(user => user.MatricNumber == dto.MatricNumber && user.Password == dto.Password).SingleOrDefault();
            if (FindVoter == null)
            {
                return new VoterResponseModel
                {
                    Message = "Voter Authentication Failed",
                    Status = false
                };
            }
            else
            {
                return new VoterResponseModel
                {
                    Data = new VoterDto
                    {
                        FullName = $"{FindVoter.FirstName} {FindVoter.LastName}",
                        MatricNumber = FindVoter.MatricNumber,
                        Password = FindVoter.Password,
                        Gender = FindVoter.Gender,
                        Id = FindVoter.Id,
                        UserRole = FindVoter.UserRole,
                        VoterRegId = FindVoter.VoterRegId
                    },
                    Status = true,
                    Message = $"Welcome Back {FindVoter.FirstName}",
                };
            }

        }

    }
}