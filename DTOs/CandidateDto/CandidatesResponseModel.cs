using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.CandidateDto
{
    public class CandidatesResponseModel : BaseResponseModel
    {
        public IList<CandidateDto> Data {get; set;}
    }
}
