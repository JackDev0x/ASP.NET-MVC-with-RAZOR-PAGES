using System.Linq;

namespace SandstoneStore.Models
{
    public class EFSandstonesRepository : IDatabaseRepository
    {
        private StoreDbContext context;

        public EFSandstonesRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

    }
}
