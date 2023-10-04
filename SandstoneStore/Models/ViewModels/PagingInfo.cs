namespace SandstoneStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int Items_total { get; set; }
        public int ProductsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int Pages_total => (int)Math.Ceiling((decimal)Items_total / ProductsPerPage);
    }
}
