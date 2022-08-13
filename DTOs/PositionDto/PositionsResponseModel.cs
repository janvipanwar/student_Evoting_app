using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.DTOs.PositionDto
{
    public class PositionsResponseModel : BaseResponseModel
    {
        public IList<PositionDto> Data { get; set; }
    }
}
