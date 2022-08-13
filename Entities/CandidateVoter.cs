using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTEVOTINGAPP.Entities
{
    public class CandidateVoter
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int Voterd { get; set; }
        public Voter Voter { get; set; }

    }
}
