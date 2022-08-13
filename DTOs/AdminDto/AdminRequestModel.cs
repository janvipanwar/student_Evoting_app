using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.AdminDto
{
    public class AdminRequestModel
    {
        public int ID { get; set; }
        public string MatricNumber { get; set; }
        public string Password { get; set; }
    }
}
