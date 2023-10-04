using Microsoft.AspNetCore.Mvc;
using SandstoneStore.Models;

namespace SandstoneStore.Components
{
    public class MyCartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public MyCartSummaryViewComponent(Cart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
