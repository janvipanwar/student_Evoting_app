using STUDENTEVOTINGAPP.DTOs.PositionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        Position CreatePosition(Position position);
        Position EditPosition(Position position);
        IList<Position> GetPositionsByElectionId(int ElectionId);
        bool PositionExist(string name);
        List<PositionDto> GetPositions();
        Position GetPosition(int id);
        bool DeletePosition(int id);
    }
}
