using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Admin CreateAdmin(Admin admin);
        Admin GetAdmin(int id);
        IList<Admin> GetAdmins();
        Admin GetAdminByMatricNumber(string MatricNumber);
        bool DeleteAdmin(int id);
        bool AdminExist(string matricnumber);
        public bool IsFinalYear(Level level);
    }
}