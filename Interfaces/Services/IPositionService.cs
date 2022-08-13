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
    public interface IPositionService
    {
        PositionResponseModel CreatePosition(PositionDto position);
        PositionResponseModel EditPosition(PositionDto position, int id);
        BaseResponseModel DeletePosition(int id);
        PositionsResponseModel GetPositionsByElectionId(int ElectionId);
        PositionsResponseModel GetPositions();
    }
}
