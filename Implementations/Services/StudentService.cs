using STUDENTEVOTINGAPP.DTOs;
using STUDENTEVOTINGAPP.DTOs.StudentDto;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class StudentService : IStudentService
    {
        public IStudentRepository _studentRepository;
        

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentResponseModel GetStudentByMatricNumber(string MatricNumber)
        {
            var student= _studentRepository.GetStudentByMatricNumber(MatricNumber);
            if (student == null)
            {
                return new StudentResponseModel
                {
                    Message = "Student Not Found",
                    Status = false
                };
            }
            return new StudentResponseModel
            {
                Data = new StudentDto
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    PhoneNUmber = student.PhoneNUmber,
                    Gender = student.Gender,
                    EmailAddress = student.EmailAddress,
                    Level = student.Level,
                    MatricNumber = student.MatricNumber,
                    Id = student.Id,
                },
                Message = "Student Sucessfully Retrieved",
                Status = true,
            };
        }

        public StudentsResponseModel GetStudents()
        {
            var students = _studentRepository.GetStudents();
            return new StudentsResponseModel
            {
                Data = students,
                Status = true,
                Message = "Students Retrieved Successfully"
            };
        }

        public BaseResponseModel RegisterStudents()
        {
            _studentRepository.CreateStudents();
            return new BaseResponseModel
            {
                Status = true,
                Message = "Students Added Successfully"
            };
        }
        
        
    }
}
