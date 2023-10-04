using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SandstoneStore.Infrastructure;
using SandstoneStore.Models;

namespace SandstoneStore.Pages
{
    public class CartModel : PageModel
    {
        private IDatabaseRepository _repository;
        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        [BindProperty]
        public int quantity_ToRemove { get; set; }

        public CartModel(IDatabaseRepository repository, Cart cart_Service)
        {
            _repository = repository;
            Cart = cart_Service;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            Cart.AddProduct(product, 1);
            
            return RedirectToPage(new
            {
                returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.Remove_line(Cart.Lines.First(f => f._product.ProductId == productId)._product, quantity_ToRemove);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
