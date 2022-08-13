using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.PositionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class PositionService : IPositionService
    {
        public IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public PositionResponseModel CreatePosition(PositionDto position)
        {
            var positionExist = _positionRepository.PositionExist(position.Name);
            if (positionExist)
            {
                return new PositionResponseModel
                {
                    Status = false,
                    Message = "Position Alreday Exist"
                };
            }
            var newposition = new Position
            {
                Name = position.Name,
               ElectionId = position.ElectionId 

            };
            _positionRepository.CreatePosition(newposition);
            return new PositionResponseModel
            {
                Data = new PositionDto
                {
                    Name = position.Name,
                    ElectionId = position.ElectionId
                },
                Status = true,
                Message = "Position Successfully Created",
            };
        }

        public BaseResponseModel DeletePosition(int id)
        {
            var position = _positionRepository.GetPosition(id);
            if (position == null)
            {
                return new BaseResponseModel
                {
                    Message = "Position Not Found",
                    Status = false
                };
            }
            _positionRepository.DeletePosition(id);
            return new BaseResponseModel
            {
                Status = true,
                Message = "Position Succesfully Deleted",
            };
        }

        public PositionResponseModel EditPosition(PositionDto position, int id)
        {
            var findPosition = _positionRepository.GetPosition(id);
            if (findPosition == null)
            {
                return new PositionResponseModel
                {
                    Message = "Position Not Found",
                    Status = false
                };
            }
            findPosition.Name = position.Name;
            findPosition.ElectionId = position.ElectionId;
            _positionRepository.EditPosition(findPosition);
            return new PositionResponseModel
            {
                Status = true,
                Message = "Election Succesfully Deleted",
            };
        }

        public PositionsResponseModel GetPositionsByElectionId(int ElectionId)
        {
            var positions = _positionRepository.GetPositionsByElectionId(ElectionId).Select(post => new PositionDto
            {
                Id = post.Id,
                Name = post.Name,
                ElectionId = post.ElectionId,
                
            }).ToList();
            if (positions == null)
            {
                return new PositionsResponseModel
                {
                    Status = false,
                    Message = "Admins Not Found",
                };
            }
            return new PositionsResponseModel
            {
                Data = positions,
                Status = true,
                Message = "Admins Sucessfully retrieved",
            };
        }
        public PositionsResponseModel GetPositions()
        {
            var positions = _positionRepository.GetPositions();
            if ( positions == null)
            {
                return new PositionsResponseModel
                {
                    Status = false,
                    Message = "No Admin Registered Yet",
                };
            }
            return new PositionsResponseModel
            {
                Data = positions,
                Status = true,
                Message = "Admins Sucessfully retrieved",
            };
        }
    }
}
