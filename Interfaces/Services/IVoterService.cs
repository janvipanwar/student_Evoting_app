using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.VoteDto;
using STUDENTEVOTINGAPP.DTOs.VoterDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IVoterService
    {
        BaseResponseModel AddVoter(CreateRequest request);
        bool DeleteVoter(int id);
        VoterResponseModel GetVoter(int id);
        VotersResponseModel GetVoters();
        VoterResponseModel VoterLogin(VoterDto dto);
    }
}
