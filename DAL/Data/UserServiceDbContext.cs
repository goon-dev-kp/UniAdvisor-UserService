using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class UserServiceDbContext : DbContext
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<SubjectScore> SubjectScores { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<StudentInterest> StudentInterests { get; set; }
        public DbSet<StudentTalent> StudentTalents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<StudentProfile>().HasKey(x => x.StudentProfileId);
            modelBuilder.Entity<SubjectScore>().HasKey(x => x.SubjectScoreId);
            modelBuilder.Entity<Interest>().HasKey(x => x.InterestId);
            modelBuilder.Entity<Talent>().HasKey(x => x.TalentId);
            modelBuilder.Entity<StudentInterest>().HasKey(x => x.StudentInterestId);
            modelBuilder.Entity<StudentTalent>().HasKey(x => x.StudentTalentId);

            // USER TOKEN
            modelBuilder.Entity<UserToken>().HasKey(t => t.RefreshTokenId);
            modelBuilder.Entity<UserToken>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationships
            modelBuilder.Entity<StudentProfile>()
                .HasOne(sp => sp.User)
                .WithOne(u => u.StudentProfile)
                .HasForeignKey<StudentProfile>(sp => sp.UserId);

            modelBuilder.Entity<SubjectScore>()
                .HasOne(ss => ss.StudentProfile)
                .WithMany(sp => sp.SubjectScores)
                .HasForeignKey(ss => ss.StudentProfileId);

            modelBuilder.Entity<StudentInterest>()
                .HasOne(si => si.StudentProfile)
                .WithMany(sp => sp.Interests)
                .HasForeignKey(si => si.StudentProfileId);

            modelBuilder.Entity<StudentInterest>()
                .HasOne(si => si.Interest)
                .WithMany(i => i.StudentInterests)
                .HasForeignKey(si => si.InterestId);

            modelBuilder.Entity<StudentTalent>()
                .HasOne(st => st.StudentProfile)
                .WithMany(sp => sp.Talents)
                .HasForeignKey(st => st.StudentProfileId);

            modelBuilder.Entity<StudentTalent>()
                .HasOne(st => st.Talent)
                .WithMany(t => t.StudentTalents)
                .HasForeignKey(st => st.TalentId);

            modelBuilder.Entity<SubjectScore>()
                .HasOne(ss => ss.Subject)
                .WithMany()
                .HasForeignKey(ss => ss.SubjectId);


            base.OnModelCreating(modelBuilder);

            // Seed data can be added here if needed
            DbSeeder.Seed(modelBuilder);
        }
    }
}
