using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.ElectionDto
{
    public class ElectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ElectionOpenDate { get; set; }
        public DateTime ElectionCloseDate { get; set; }
        public virtual List<Position> Positions { get; set; } = new List<Position>();
    }
}
