namespace SandstoneStore.Models
{
    public interface IOrdersRepo
    {
        IQueryable<MyOrder> Orders { get; }
        void SaveOrder(MyOrder currentOrder);
    }
}
