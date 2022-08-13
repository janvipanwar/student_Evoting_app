using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoteDto
{
    public class VoteDto
    {
        public int Id { get; set; }
        public string MatricNumber { get; set; }
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int VoteCount { get; set; }

    }
}
