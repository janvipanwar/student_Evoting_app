using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTEVOTINGAPP.Entities
{
    public class Election
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ElectionOpenDate { get; set; }
        public DateTime ElectionCloseDate { get; set; }
        public virtual List<Position> Positions { get; set; } = new List<Position>();
    }
}