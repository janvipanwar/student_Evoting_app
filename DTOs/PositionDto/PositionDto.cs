using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.PositionDto
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
        public string ElectionName { get; set; }
    }
}
