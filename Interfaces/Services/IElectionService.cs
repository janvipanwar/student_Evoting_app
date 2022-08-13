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
    public interface IElectionService
    {
        ElectionResponseModel CreateElection(ElectionDto dto);
        ElectionResponseModel EditElection(ElectionDto dto, int id);
        BaseResponseModel DeleteElection(int id);
        ElectionResponseModel GetElection(int id);
        ElectionsResponseModel GetElections();
    }
}
