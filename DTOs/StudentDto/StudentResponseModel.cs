using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.StudentDto
{
    public class StudentResponseModel : BaseResponseModel
    {
        public StudentDto Data { get; set; }
        public IList<StudentDto> Datas { get; set; }
    }
}
