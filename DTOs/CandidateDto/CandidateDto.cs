using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.CandidateDto
{
    public class CandidateDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MatricNum { get; set; }
        public UserRole User { get; set; }
        public int PositionId { get; set; }
        public int ElectionId { get; set; }
        public string PositionName { get; set; }
        public string ElectionName { get; set; }
    }
}
