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
    public class StudentTalentRepository : GenericRepository<StudentTalent>, IStudentTalentRepository
    {
        private readonly UserServiceDbContext _context;
        public StudentTalentRepository(UserServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
