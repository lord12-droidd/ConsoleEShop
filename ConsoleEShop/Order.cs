using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEShop
{
    class Order
    {
        List<Product> order = new List<Product>();
        OrderStatus status = OrderStatus.New;
        public OrderStatus Status { get; set; }

        public List<Product> GetOrder()
        {
            order.ToString();
            return order;
        }
        public RegistredGuest Receiver { private set; get; }

        public decimal FullCost { set; get; }
        public Order(RegistredGuest receiver)
        {
            Receiver = receiver;
        }
        public Order(List<Product> products, RegistredGuest receiver)
        {
            order = products;
            FullCost = order.Sum(n => n.Cost);
            Receiver = receiver;
            status = OrderStatus.New;
        }
        public void AddProduct(Product product)
        {
            order.Add(product);
        }
        public override string ToString()
        {
            foreach(var product in order)
            {
                product.ToString();
            }
            return $"Полная стоимость заказа: {FullCost},";
        }
    }
}
