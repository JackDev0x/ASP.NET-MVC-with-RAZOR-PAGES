using Microsoft.AspNetCore.Mvc;
using SandstoneStore.Models;
using SandstoneStore.Pages;
using SandstoneStore.Infrastructure;

namespace SandstoneStore.Components 
{
    public class CartPreviewViewComponent : ViewComponent
    {
        private IDatabaseRepository _repository;
        Cart? Cart { get; set; }
        public CartPreviewViewComponent(Cart cart)
        {
            Cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Valuess = RouteData?.Values["preview"];
            return View(Cart);
        }
    }
}
