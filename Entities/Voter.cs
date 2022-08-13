using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTEVOTINGAPP.Entities
{
    public class Voter : User
    {
        public string MatricNumber { get; set; }
        public string VoterRegId { get; set; }
        public UserRole UserRole { get; set; }
        public List<VoterVote> VoterVotes { get; set; } = new List<VoterVote>();
        public virtual List<CandidateVoter> Voters { get; set; } = new List<CandidateVoter>();

    }
}
