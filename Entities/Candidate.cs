using System;
using STUDENTEVOTINGAPP.Models;
using System.Collections.Generic;
using System.Text;
using STUDENTEVOTINGAPP.Enums;

namespace STUDENTEVOTINGAPP.Entities
{
    public class Candidate 
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MatricNum { get; set; }
        public UserRole User { get; set; }
        public int PositionId { get; set; }
        public Position Positions { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
        public virtual List<CandidateVoter> Voters { get; set; } = new List<CandidateVoter>();
    }
}
