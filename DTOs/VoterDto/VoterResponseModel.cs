using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoterDto
{
    public class VoterResponseModel : BaseResponseModel
    {
        public VoterDto Data { get; set; }
    }
}
