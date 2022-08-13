using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using STUDENTEVOTINGAPP.Entities;
using STUDENTEVOTINGAPP.Enums;
using STUDENTEVOTINGAPP.Models;
using System;

namespace STUDENTEVOTINGAPP.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateVoter> CandidateVoters { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Voter> Voters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Admin>().HasData
             (
                new Admin
                {
                    Id = 1,
                    FirstName = "Jaspa",
                    LastName = "Dembaba",
                    MatricNum = $"ST{Guid.NewGuid().ToString().Replace(" - ", "").Substring(0, 7).ToUpper()}",
                    EmailAddress = "Dembaba@gmail.com",
                    PhoneNUmber = "08098987654",
                    Password = "password",
                    Level = Level.Level500,
                    Gender = Gender.Male,
                    UserRole = UserRole.SuperAdmin,
                }
             );
        }
        public override DatabaseFacade Database => base.Database;
        public override ChangeTracker ChangeTracker => base.ChangeTracker;
        public override IModel Model => base.Model;
        public override DbContextId ContextId => base.ContextId;
    }
}
