using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.ElectionDto
{
    public class ElectionsResponseModel : BaseResponseModel
    {
        public IList<ElectionDto> Data { get; set; }
    }
}
