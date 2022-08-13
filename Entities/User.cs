using STUDENTEVOTINGAPP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENTEVOTINGAPP.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNUmber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
    }
}
