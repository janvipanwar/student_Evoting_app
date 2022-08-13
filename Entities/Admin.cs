using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTEVOTINGAPP.Entities
{
    public class Admin : User
    {
        public string MatricNum { get; set; }
        public Level Level { get; set; }
        public UserRole UserRole { get; set; }
    }
}
