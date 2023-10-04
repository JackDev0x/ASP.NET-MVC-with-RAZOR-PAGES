namespace SandstoneStore.Models
{
    public interface IDatabaseRepository
    {
        IQueryable<Product> Products { get; }
    }
}
