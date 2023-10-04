using Microsoft.AspNetCore.Mvc;
using SandstoneStore.Models;
using System.Data.Common;

namespace SandstoneStore.Controllers
{

    public class OrderController : Controller
    {
        IOrdersRepo ordersRepo;
        private Cart cart;

        public OrderController(IOrdersRepo ordersRepo, Cart cart)
        {
            this.ordersRepo = ordersRepo;
            this.cart = cart;
        }

        public ViewResult SubmitOrder()
        {
            return View(new MyOrder());
        }

        [HttpPost]
        public IActionResult SubmitOrder(MyOrder order)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.CartLines = cart.Lines.ToArray();
                ordersRepo.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/OrderCompleted");
            }
            else
            {
                return View();
            }
            
        }
    }
}