using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.ElectionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class ElectionService : IElectionService
    {
        public IElectionRepository _electionRepository;

        public ElectionService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public ElectionResponseModel CreateElection(ElectionDto dto)
        {
            var electionExist = _electionRepository.ElectionExist(dto.Name);
            if (electionExist)
            {
                return new ElectionResponseModel
                {
                    Status = false,
                    Message = "Election Alreday Exist"
                };
            }
            var election = new Election
            {
                Name = dto.Name,
                ElectionOpenDate = dto.ElectionOpenDate,
                ElectionCloseDate = dto.ElectionCloseDate,
                
            };
            _electionRepository.CreateElection(election);
            return new ElectionResponseModel
            {
                Data = new ElectionDto
                {
                    Name = election.Name,
                    ElectionOpenDate = election.ElectionOpenDate,
                    ElectionCloseDate = election.ElectionCloseDate
                },
                Status = true,
                Message = "Election Successfully Created",
            };
        }

        public BaseResponseModel DeleteElection(int id)
        {
            var elcetion = _electionRepository.GetElection(id);
            if (elcetion == null)
            {
                return new BaseResponseModel
                {
                    Message = "Election Not Found",
                    Status = false
                };
            }
            _electionRepository.DeleteElection(id);
            return new BaseResponseModel
            {
                Status = true,
                Message = "Election Succesfully Deleted",
            };

        }

        public ElectionResponseModel EditElection(ElectionDto dto, int id)
        {
            var elcetion = _electionRepository.GetElection(id);
            if (elcetion == null)
            {
                return new ElectionResponseModel
                {
                    Message = "Election Not Found",
                    Status = false
                };
            }
            elcetion.Name = dto.Name;
            elcetion.ElectionOpenDate = dto.ElectionOpenDate;
            elcetion.ElectionCloseDate = dto.ElectionCloseDate;
            _electionRepository.EditElection(elcetion);
            return new ElectionResponseModel
            {
                Status = true,
                Message = "Election Succesfully Deleted",
            };
        }

        public ElectionResponseModel GetElection(int id)
        {
            var elction = _electionRepository.GetElection(id);
            if (elction == null)
            {
                return new ElectionResponseModel
                {
                    Message = "Election Not Found",
                    Status = false,
                };
            }
            else
            {
                return new ElectionResponseModel
                {
                    Data = new ElectionDto
                    {
                        Name = elction.Name,
                        ElectionOpenDate = elction.ElectionOpenDate,
                        ElectionCloseDate = elction.ElectionCloseDate
                    },
                    Message = "Election Successfully Retrieved",
                    Status = true
                };
            }
        }

        public ElectionsResponseModel GetElections()
        {
            var election = _electionRepository.GetElections().Select(elects => new ElectionDto 
            { 
                Id = elects.Id,
                Name = elects.Name,
                ElectionOpenDate = elects.ElectionOpenDate,
                ElectionCloseDate = elects.ElectionCloseDate
            }).ToList();
            if (election == null)
            {
                return new ElectionsResponseModel
                {
                    Status = false,
                    Message = "Admins Not Found",
                };
            }
            return new ElectionsResponseModel
            {
                Data = election,
                Status = true,
                Message = "Admins Sucessfully retrieved",
            };
        }
    }
}
