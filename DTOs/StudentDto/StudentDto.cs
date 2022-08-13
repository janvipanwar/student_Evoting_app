using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.StudentDto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNUmber { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public string MatricNumber { get; set; }
        public Level Level { get; set; }
    }
}
