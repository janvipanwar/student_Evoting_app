using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.AdminDto
{
    public class AdminResponseModel : BaseResponseModel
    {
        public AdminDto Data { get; set; }
    }
}
