﻿namespace SandstoneStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product>? Products { get; set; } = Enumerable.Empty<Product>();
        public PagingInfo? PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        
    }
}
