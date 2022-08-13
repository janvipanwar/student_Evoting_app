using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.CandidateDto
{
    public class CreateCandidateRequestModel
    {
        public string PositionName { get; set; }
        public int PositionId { get; set; }
        public string ElectionName { get; set; }
        public int ElectionId { get; set; }
    }
}
