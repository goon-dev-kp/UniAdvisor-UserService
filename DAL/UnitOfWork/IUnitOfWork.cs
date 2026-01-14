using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interface;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IInterestRepository InterestRepo { get; }
        IStudentProfileRepository StudentProfileRepo { get; }
        IStudentTalentRepository StudentTalentRepo { get; }
        ISubjectRepository SubjectRepo { get; }
        IStudentInterestRepository StudentInterestRepo { get; }
        ISubjectScoreRepository SubjectScoreRepo { get; }
        ITalentRepository TalentRepo { get; }
        IUserRepository UserRepo { get; }
        ITokenRepository TokenRepo { get; }
        Task<int> SaveAsync();
        Task<bool> SaveChangeAsync();
    }
}
