using STUDENTEVOTINGAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.AdminDto
{
    public class AdminsResponseModel : BaseResponseModel
    {
        public IList<Admin> Data { get; set; }

    }
}
