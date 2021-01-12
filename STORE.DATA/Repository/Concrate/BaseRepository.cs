using Microsoft.EntityFrameworkCore;
using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using STORE.ENTITY.Includable.Abstract;
using STORE.ENTITY.Includable.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STORE.DATA.Repository.Concrate
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : BaseEntity
    {
        //Buradaki sıkıntıdan dolayı emreden mantık yardımı lazım 
        protected readonly DbSet<Tentity> _dbSet;

        public BaseRepository(StoreContext storeContext)
        {
            _dbSet = storeContext.Set<Tentity>();
        }

        public async Task<Tentity> AddAsync(Tentity tentity)
        {
            tentity.InsertedDate = DateTime.Now;
            await _dbSet.AddAsync(tentity).ConfigureAwait(false);

            return tentity;
        }

        public async Task<IEnumerable<Tentity>> AddRangeAsync(IEnumerable<Tentity> tentities)
        {
            foreach (var item in tentities)
                item.InsertedDate = DateTime.Now;
            
            await _dbSet.AddRangeAsync(tentities).ConfigureAwait(false);

            return tentities;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Tentity> tentities)
        {
            _dbSet.RemoveRange(tentities);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.IncludeMultiple(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Tentity> GetByIdAsync(int id, Func<IIncludable<Tentity>, IIncludable> predicate = null)
        {
            return await _dbSet.IncludeMultiple(predicate).FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public Tentity Update(Tentity tentity)
        {
            _dbSet.Update(tentity);

            return tentity;
        }

        public IEnumerable<Tentity> UpdateRange(IEnumerable<Tentity> tentities)
        {
            _dbSet.UpdateRange(tentities);

            return tentities;
        }
    }
}
