
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.PositionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationContext _context;
        public PositionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Position CreatePosition(Position position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
            return position;
        }

        public bool DeletePosition(int id)
        {
            var position = _context.Positions.Find(id);
            _context.Positions.Remove(position);
            _context.SaveChanges();
            return true;
        }

        public Position EditPosition(Position position)
        {
            _context.Positions.Update(position);
            _context.SaveChanges();
            return position;
        }

        public IList<Position> GetPositionsByElectionId(int electionId)
        {
            var positions = _context.Positions.Where(position => position.ElectionId == electionId).ToList();
            return positions;
        }

        public bool PositionExist(string name)
        {
                var postExist = _context.Positions.Any(admin => admin.Name == name);
                return postExist;
             
        }

        public List<PositionDto> GetPositions()
        {
            var positions = _context.Positions.Select(pos => new PositionDto
            {
                Id = pos.Id,
                Name = pos.Name,
                ElectionId = pos.ElectionId,
                ElectionName = pos.Election.Name
            }).ToList();
            return positions;
        }

        public Position GetPosition(int id)
        {
            var position = _context.Positions.Find(id);
            return position;
        }

      
    }
}
