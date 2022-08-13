using Microsoft.AspNetCore.Hosting;
using STUDENTEVOTINGAPP.Context;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace STUDENTEVOTINGAPP.Interfaces.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        private static List<Student> Students = StudentList();

        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        
        public bool CreateStudents()
        {
            _context.Students.AddRange(Students);
            _context.SaveChanges();
            return true;
        }

        public Student GetStudentByMatricNumber(string matricNumber)
        {
            var admin = _context.Students.SingleOrDefault(User => User.MatricNumber == matricNumber);
            return admin;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public static List<Student> StudentList()
        {
            List<Student> students = new List<Student>()
          {
                new Student
            {
                Id = 1,
                FirstName = "Joshu",
                LastName = "imilo",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level500,
                EmailAddress = "joshua@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 2,
                FirstName = "fatik",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level200,
                EmailAddress = "galit@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 3,
                FirstName = "Segun",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level100,
                EmailAddress = "segun@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 4,
                FirstName = "holit",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level200,
                EmailAddress = "holit@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 5,
                FirstName = "dembaba",
                LastName = "hou",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level500,
                EmailAddress = "hou@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 6,
                FirstName = "Tinka",
                LastName = "baaik",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level300,
                EmailAddress = "baaik@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 7,
                FirstName = "Segun",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level500,
                EmailAddress = "segun@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 8,
                FirstName = "joy",
                LastName = "rowee",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level200,
                EmailAddress = "rowee@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 9,
                FirstName = "mile",
                LastName = "ilimu",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level400,
                EmailAddress = "mile@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 10,
                FirstName = "mail",
                LastName = "kali",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level100,
                EmailAddress = "kali@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 11,
                FirstName = "damili",
                LastName = "joy",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level400,
                EmailAddress = "joy@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 12,
                FirstName = "mkile",
                LastName = "loli",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level500,
                EmailAddress = "loli@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 13,
                FirstName = "jamil",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level300,
                EmailAddress = "jamil@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 14,
                FirstName = "Segun",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level100,
                EmailAddress = "segun@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 15,
                FirstName = "maai",
                LastName = "Tukir",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level100,
                EmailAddress = "maai@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 16,
                FirstName = "Tunji",
                LastName = "ojo",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level400,
                EmailAddress = "ojo@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 17,
                FirstName = "Usman",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level300,
                EmailAddress = "usman@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 18,
                FirstName = "Tunde",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level200,
                EmailAddress = "tunde@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Female,
                Password = "password",
                UserRole = UserRole.student,
            },new Student
            {
                Id = 19,
                FirstName = "Segun",
                LastName = "jimi",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level400,
                EmailAddress = "jimi@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },
                new Student
            {
                Id = 20,
                FirstName = "Fatai",
                LastName = "Gold",
                MatricNumber = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                Level = Level.Level500,
                EmailAddress = "fata@gmail.com",
                PhoneNUmber = "08098987654",
                Gender = Gender.Male,
                Password = "password",
                UserRole = UserRole.student,
            },
            
          };
            return students;
        }
       
    }
}
