
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.DTOs.AdminDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationContext _context;
        public IAdminRepository _adminRepository;
        public IStudentRepository _studentRepository;

        public AdminService(IAdminRepository adminRepository, ApplicationContext context, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _context = context;
            _studentRepository = studentRepository;
        }

        public AdminResponseModel AminLogin(AdminRequestModel request)
        {
            var FindAdmin = _context.Admins.Where(user => user.MatricNum == request.MatricNumber && user.Password 
            == request.Password).SingleOrDefault();
            if (FindAdmin == null)
            {
                return new AdminResponseModel
                {
                    Message = "Admin Authentication Failed",
                    Status = false
                };
            }
            else
            {
                return new AdminResponseModel
                {
                    Data = new AdminDto
                    {
                        FullName = $"{FindAdmin.FirstName} {FindAdmin.LastName}",
                        MatricNum = FindAdmin.MatricNum,
                        Password = FindAdmin.Password,
                        Gender = FindAdmin.Gender
                    },
                    Status = true,
                    Message = "Admin Log in Successfully"
                };
            }
            
        }

        public AdminResponseModel DeleteAdmin(int Id)
        {
            var Admin = _adminRepository.GetAdmin(Id);
            if (Admin == null )
            {
                return new AdminResponseModel
                {
                    Message = "Admin Not Found",
                    Status = false
                };
            }
            else
            {
                _adminRepository.DeleteAdmin(Id);
                return new AdminResponseModel
                {
                    Message = "Admin Deleted Successfully",
                    Status = true
                };
            }
           
        }
        public AdminResponseModel RegisterAdmin(AdminRequestModel request)
        {
            var student = _studentRepository.GetStudentByMatricNumber(request.MatricNumber);
            if ( student == null)
            {
                return new AdminResponseModel
                {
                    Message = "student Not Found",
                    Status = false
                };
            }
            else
            {
                var AdminExist = _adminRepository.AdminExist(request.MatricNumber);
                var IsFinalYearStudent = _adminRepository.IsFinalYear(student.Level);
                if (AdminExist)
                {
                    return new AdminResponseModel
                    {
                        Message = "Admin Already Exist",
                        Status = false
                    };
                }
                if (!IsFinalYearStudent )
                {
                    return new AdminResponseModel
                    {
                        Message = "Not Eligible to be An Admin",
                        Status = false
                    };
                }
                if (_context.Admins.Count() > 5)
                {
                    return new AdminResponseModel
                    {
                        Message = "Admin limit Reached",
                        Status = false
                    };
                }
                var newAdmin = new Admin
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    PhoneNUmber = student.PhoneNUmber,
                    EmailAddress = student.EmailAddress,
                    Gender = student.Gender,
                    MatricNum = student.MatricNumber,
                    Level = student.Level,
                    Password = student.Password,
                    UserRole = UserRole.Admin,
                };
                _adminRepository.CreateAdmin(newAdmin);
                return new AdminResponseModel
                {
                    Data = new AdminDto
                    {
                        FullName = $"{newAdmin.FirstName} {newAdmin.LastName}",
                        MatricNum = newAdmin.MatricNum,
                        Password = newAdmin.Password,
                        Gender = newAdmin.Gender,
                    },
                    Status = true,
                    Message = "Admin created succesfully"
                };
            }
            
        }
        public AdminResponseModel GetAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new AdminResponseModel
                {
                    Message = "Admin not found ",
                    Status = false
                };
            }
            return new AdminResponseModel
            {
                Data = new AdminDto
                {
                    ID = admin.Id,
                    FullName = $"{admin.FirstName} {admin.LastName}",
                    MatricNum = admin.MatricNum,
                    Gender = admin.Gender,
                    Password = admin.Password
                },
                Message = "Admin Retrieve Successfully",
                Status = true
            };
        }

        public AdminsResponseModel GetAdmins()
        {
            var admins = _adminRepository.GetAdmins();
            if (admins == null)
            {
                return new AdminsResponseModel
                {
                    Status = false,
                    Message = "Admins Not Found",
                };
            }
            return new AdminsResponseModel
            {
                Data = admins,
                Status = true,
                Message = "Admins Sucessfully retrieved",
            };
        }
    }
}
