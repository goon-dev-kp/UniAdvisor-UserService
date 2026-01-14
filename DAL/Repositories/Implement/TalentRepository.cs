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
    public class TalentRepository : GenericRepository<Talent>, ITalentRepository
    {
        private readonly UserServiceDbContext _context;
        public TalentRepository(UserServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
