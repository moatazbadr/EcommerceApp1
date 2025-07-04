using EcommerceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.classes
{
    public  class Cart
    {
        private readonly List<CartItem> _items =new List<CartItem>();
        public IReadOnlyList<CartItem> items => _items;

        public void AddItem(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(item => item.product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }
        public decimal SubTotal => _items.Sum(item => item.TotalPrice);
        public IEnumerable<IShippable> shippablesItems => _items.Select(item => item.product)
                                                                     .OfType<IShippable>();
        public void RemoveItem(Product product)
        {
            var itemToRemove = _items.FirstOrDefault(item => item.product.Name == product.Name);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }
        public List<CartItem> RemoveExpiredItemsAndReturnThem()
        {
            var expired = _items.Where(item => item.product is IExpirable expirable && expirable.IsExpired).ToList();
            _items.RemoveAll(item => expired.Contains(item));
            return expired;
        }
        public double TotalWeight => _items
      .Where(item => item.product is IShippable)
      .Sum(item => ((IShippable)item.product).GetWeight() * item.Quantity);



    }
}
