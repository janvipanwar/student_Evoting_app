using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoteDto
{
    public class VoteResponseModel : BaseResponseModel
    {
        public VoteDto Data { get; set; }
    }
}
