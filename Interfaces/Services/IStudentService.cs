using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.StudentDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IStudentService
    {
        BaseResponseModel RegisterStudents();
        StudentResponseModel GetStudentByMatricNumber(string MatricNumber);
        StudentsResponseModel GetStudents();
    }
}
