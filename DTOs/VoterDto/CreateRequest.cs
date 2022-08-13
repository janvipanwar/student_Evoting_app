using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.VoterDto
{
    public class CreateRequest
    {
        public int ID { get; set; }
        public string MatricNumber { get; set; }
    }
}
