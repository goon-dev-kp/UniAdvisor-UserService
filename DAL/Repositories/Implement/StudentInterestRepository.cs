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
    public class StudentInterestRepository : GenericRepository<StudentInterest>, IStudentInterestRepository
    {
        private readonly UserServiceDbContext _context;
        public StudentInterestRepository(UserServiceDbContext context) : base(context)
        {
            _context = context;
        }
        // Additional methods specific to StudentInterest can be added here
    }
}
