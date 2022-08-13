using STUDENTEVOTINGAPP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.AdminDto
{
    public class AdminDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MatricNum { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public UserRole UserRole { get; set; }
       
    }
}
