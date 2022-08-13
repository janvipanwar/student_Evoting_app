using STUDENTEVOTINGAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.StudentDto
{
    public class StudentsResponseModel : BaseResponseModel
    {
        public IList<Student> Data { get; set; }
    }
}
