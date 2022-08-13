using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.ElectionDto
{
    public class ElectionResponseModel : BaseResponseModel
    {
        public ElectionDto Data { get; set; }
    }
}
