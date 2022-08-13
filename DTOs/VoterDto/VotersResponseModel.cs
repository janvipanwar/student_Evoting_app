using STUDENTEVOTINGAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoterDto
{
    public class VotersResponseModel : BaseResponseModel 
    {
        public IList<Voter> Data { get; set; }
    }
}
