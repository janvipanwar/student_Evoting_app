
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool AdminExist(string matricnumber)
        {
          return  _context.Admins.Any(admin => admin.MatricNum == matricnumber);
        }

        public Admin CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }
        public bool DeleteAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return true;
        }

        public Admin GetAdmin(int id)
        {
            return _context.Admins.Find(id);
        }

        public Admin GetAdminByMatricNumber(string MatricNumber)
        {
            var admin = _context.Admins.SingleOrDefault(User => User.MatricNum == MatricNumber);
            return admin;
        }

        public IList<Admin> GetAdmins()
        {
            var admins = _context.Admins.Select(user => new Admin
            { 
                Id = user.Id,
                FirstName  = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PhoneNUmber = user.PhoneNUmber,
                MatricNum = user.MatricNum,
                Password = user.Password,
                UserRole = user.UserRole,
                Gender = user.Gender,
                Level = user.Level
            }).ToList();

            return admins;
        }

        public bool IsFinalYear(Level level)
        {
            var levelStatus = level == Level.Level400 || level == Level.Level500;
            return levelStatus;
        }
    }
}
