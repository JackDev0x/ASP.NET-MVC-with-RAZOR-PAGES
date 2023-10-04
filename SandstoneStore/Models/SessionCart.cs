using System.Data.Common;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SandstoneStore.Infrastructure;

namespace SandstoneStore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }



        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddProduct(Product product, int quantity)
        {
            base.AddProduct(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void Remove_line(Product product, int quantityToRemove)
        {
            base.Remove_line(product, quantityToRemove);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }

        
    }
}
