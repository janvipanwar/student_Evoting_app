
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.ElectionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class ElectionRepository : IElectionRepository
    {
        private readonly ApplicationContext _context;

        public ElectionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool CreateElection(Election election)
        {
            _context.Elections.Add(election);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteElection(int id)
        {
            var election = _context.Elections.Find(id);
            _context.Elections.Remove(election);
            _context.SaveChanges();
            return true;
        }

        public Election EditElection(Election election)
        {
            _context.Elections.Update(election);
            _context.SaveChanges();
            return election;
        }

        public bool ElectionExist(string name)
        {
            return _context.Elections.Any(election => election.Name == name);
        }
        public bool ElectionExistId(int id)
        {
            return _context.Elections.Any(election => election.Id == id);
        }

        public Election GetElection(int id)
        {
            return _context.Elections.Find(id);
        }

        public IList<Election> GetElections()
        {
            return _context.Elections.ToList();
        }
    }
}
