using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class DbSeeder
    {
        private readonly UserServiceDbContext _context;

        // ID Mẫu
        private static readonly Guid PremiumService1 = Guid.Parse("34567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService2 = Guid.Parse("B4567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService3 = Guid.Parse("C4567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService4 = Guid.Parse("D4567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService5 = Guid.Parse("E4567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService6 = Guid.Parse("F4567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService7 = Guid.Parse("14567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService8 = Guid.Parse("24567890-ABCD-EF12-3456-7890ABCDEFAB");
        private static readonly Guid PremiumService9 = Guid.Parse("34567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService10 = Guid.Parse("44567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService11 = Guid.Parse("54567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService12 = Guid.Parse("64567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService13 = Guid.Parse("74567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService14 = Guid.Parse("84567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService15 = Guid.Parse("94567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService16 = Guid.Parse("A4567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid PremiumService17 = Guid.Parse("B4567890-ABCD-EF12-3456-7890ABCDEFAC");
        private static readonly Guid VehicleCustomerTestId = Guid.Parse("12345678-90AB-CDEF-1234-567890ABCDEF");
        private static readonly Guid RescueStationId1 = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF1");
        private static readonly Guid RescueStationId2 = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF2");

        // USER
        private static readonly Guid Admin_Id = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF3");
        private static readonly Guid Student_Id = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF4");
        private static readonly Guid Data_Entry_Id = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDEF5");

        public DbSeeder(UserServiceDbContext context)
        {
            _context = context;
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedUser(modelBuilder);
        }

        private static void SeedUser(ModelBuilder modelBuilder)
        {
            //pass: 123
            string fixedHashedPassword = "$2a$11$rTz6DZiEeBqhVrzF25CgTOBPf41jpn2Tg/nnIqnX8KS6uIerB/1dm";
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = Admin_Id,
                    Email = "admin@gmail.com",
                    Username = "admin",
                    PasswordHash = fixedHashedPassword,
                    Role = RoleType.ADMIN
                },
                new User
                {
                    UserId = Student_Id,
                    Email = "student@gmail.com",
                    Username = "student",
                    PasswordHash = fixedHashedPassword,
                    Role = RoleType.STUDENT
                },
                new User
                {
                    UserId = Data_Entry_Id,
                    Email = "data@gmail.com",
                    Username = "data",
                    PasswordHash = fixedHashedPassword,
                    Role = RoleType.DATA_ENTRY_OPERATOR
                }

                );
        }

    }
}


