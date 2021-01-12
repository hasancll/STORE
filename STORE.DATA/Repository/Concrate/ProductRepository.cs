using Microsoft.EntityFrameworkCore;
using STORE.DATA.Repository.Abstract;
using STORE.ENTITY.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.DATA.Repository.Concrate
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public async Task<Product> GetByBarcodeProduct(string barcode)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(p => p.Barcode == barcode).ConfigureAwait(false);

            return entity;
        }
    }
}
