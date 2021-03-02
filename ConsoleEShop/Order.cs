using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEShop
{
    public class Order
    {
        List<Product> order = new List<Product>();
        public OrderStatus Status { get; set; }
        public int ID { set; get; }
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
            ID = OrderLocalDB.GetOrders.Count + 1;
            order = products;
            FullCost = CountFullPrice();
            Receiver = receiver;
            Status = OrderStatus.New;
        }
        public Order(List<Product> order)
        {
            this.order = order;
        }
        public decimal CountFullPrice()
        {
            decimal sum = 0;
            for(int i = 0; i < order.Count; i++)
            {
                sum = sum + order[i].Cost;
            }
            return sum;
        }
        public void AddProduct(Product product)
        {
            order.Add(product);
        }
        public override string ToString()
        {
            foreach(var product in order)
            {
                Console.WriteLine(product);
                Console.WriteLine($"{Status}");
            }
            return $" ID: {ID}";
        }
    }
}
