using STUDENTEVOTINGAPP.DTOs.ElectionDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IElectionRepository
    {
        bool CreateElection(Election election);
        Election EditElection(Election election);
        bool DeleteElection(int id);
        Election GetElection(int id);
        IList<Election> GetElections();
        bool ElectionExist(string name);
        bool ElectionExistId(int id);
    }
}
