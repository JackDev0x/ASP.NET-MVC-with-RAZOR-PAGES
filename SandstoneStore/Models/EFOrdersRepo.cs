using Microsoft.EntityFrameworkCore;

namespace SandstoneStore.Models
{
    public class EFOrdersRepo : IOrdersRepo
    {
        StoreDbContext con;
        public EFOrdersRepo(StoreDbContext ctx)
        {
            con = ctx;
        }

        public IQueryable<MyOrder> Orders => con.Orders.Include(f => f.CartLines).ThenInclude(i => i._product);

        public void SaveOrder(MyOrder currentOrder)
        {
            con.AttachRange(currentOrder.CartLines.Select(f => f._product));
            if(currentOrder.Id == 0)
            {
                con.Orders.Add(currentOrder);
            }
            con.SaveChanges();
        }
    }
}
