using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IAdminService
    {
        AdminResponseModel RegisterAdmin(AdminRequestModel request);
        AdminResponseModel DeleteAdmin(int Id);
        AdminResponseModel AminLogin(AdminRequestModel request);
        AdminResponseModel GetAdmin(int id);
        AdminsResponseModel GetAdmins();
    }

    
}
