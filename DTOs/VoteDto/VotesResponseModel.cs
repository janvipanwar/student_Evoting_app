using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoteDto
{
    public class VotesResponseModel : BaseResponseModel
    {
        public IEnumerable<VoteDto> Data { get; set; }
    }
}
