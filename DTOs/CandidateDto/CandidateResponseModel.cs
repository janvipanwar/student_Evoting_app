using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.CandidateDto
{
    public class CandidateResponseModel : BaseResponseModel
    {
        public CandidateDto Data { get; set; }
    }
}
