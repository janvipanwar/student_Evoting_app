using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IStudentRepository
    {
         bool CreateStudents();
        Student GetStudentByMatricNumber(string MatricNumber);
        List<Student> GetStudents();
    }
}
