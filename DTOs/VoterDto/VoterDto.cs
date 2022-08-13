using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoterDto
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string MatricNumber { get; set; }
        public string VoterRegId { get; set; }
        public UserRole UserRole { get; set; }
        public List<VoterVote> VoterVotes { get; set; } = new List<VoterVote>();
        public virtual List<CandidateVoter> Voters { get; set; } = new List<CandidateVoter>();
    }
}
