using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Repositories.Implement;
using DAL.Repositories.Interface;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserServiceDbContext _context;
        public UnitOfWork(UserServiceDbContext context)
        {
            _context = context;
            UserRepo = new UserRepository(_context);
            StudentProfileRepo = new StudentProfileRepository(_context);
            StudentTalentRepo = new StudentTalentRepository(_context);
            StudentInterestRepo = new StudentInterestRepository(_context);
            InterestRepo = new InterestRepository(_context);
            TalentRepo = new TalentRepository(_context);
            SubjectRepo = new SubjectRepository(_context);
            SubjectScoreRepo = new SubjectScoreRepository(_context);
            TokenRepo = new TokenRepository(_context);

        }
        public IInterestRepository InterestRepo { get; private set; }
        public IStudentProfileRepository StudentProfileRepo { get; private set; }
        public IStudentTalentRepository StudentTalentRepo { get; private set; }
        public IStudentInterestRepository StudentInterestRepo { get; private set; }
        public ISubjectRepository SubjectRepo { get; private set; }
        public ISubjectScoreRepository SubjectScoreRepo { get; private set; }
        public ITalentRepository TalentRepo { get; private set; }
        public IUserRepository UserRepo { get; private set; }
        public ITokenRepository TokenRepo { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
