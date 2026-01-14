using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interface;

namespace DAL.Repositories.Implement
{
    public class StudentProfileRepository : GenericRepository<StudentProfile>, IStudentProfileRepository
    {
        private readonly UserServiceDbContext _context;
        public StudentProfileRepository(UserServiceDbContext context) : base(context)
        {
            _context = context;
        }
        // You can add any specific methods for StudentProfile here if needed
    }
}
