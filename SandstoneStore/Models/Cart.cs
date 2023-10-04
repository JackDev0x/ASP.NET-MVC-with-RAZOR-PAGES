namespace SandstoneStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public int x = 9;

        public virtual void AddProduct(Product product, int quantity)
        {
            CartLine line = Lines.Where(f => f._product.ProductId == product.ProductId).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine()
                {
                    _product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void Remove_line(Product product, int quantityToRemove)
        {
            var _line = Lines.Where(f => f._product.ProductId == product.ProductId).FirstOrDefault();

            var linesToRemove = Lines.Where(l => l._product.ProductId == product.ProductId).Take(quantityToRemove).ToList();

            if (_line.Quantity == quantityToRemove)
            {
                foreach (var lineToRemove in linesToRemove)
                {
                    Lines.Remove(lineToRemove);
                }
            }
            else if (_line.Quantity > quantityToRemove)
            {
                Lines.Where(l => l._product.ProductId == product.ProductId).First().Quantity -= quantityToRemove;
                //Lines.Where(l => l._product.ProductId == product.ProductId).First()._product.Price -= quantityToRemove* Lines.Where(l => l._product.ProductId == product.ProductId).First()._product.Price;
            }
        }

    public decimal ComputeTotalValue() =>
            Lines.Sum(e => e._product.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();

    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product _product { get; set; }
        public int Quantity { get; set; }
    }
}