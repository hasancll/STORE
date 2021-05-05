using LinqKit;
using STORE.ENTITY.Entities;
using STORE.ENTITY.Includable.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace STORE.DATA.Repository.Abstract
{
    public interface IBaseRepository<Tentity> where Tentity : BaseEntity
    {
        Task<Tentity> AddAsync(Tentity tentity);
        Task<IEnumerable<Tentity>> AddRangeAsync(IEnumerable<Tentity> tentities);
        Task<Tentity> GetByIdAsync(int id, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> GetAllAsync(Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> GetAllAsync(ExpressionStarter<Tentity> expressionStarter, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> expression, Func<IIncludable<Tentity>, IIncludable> predicate = null);
        Task DeleteAsync(int id);
        void DeleteRange(IEnumerable<Tentity> tentities);
        Tentity Update(Tentity tentity);
        IEnumerable<Tentity> UpdateRange(IEnumerable<Tentity> tentities);
    }
}
