using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class OrderLocalDB
    {
        static private List<Order> ordersDB = new List<Order>();
        static public List<Order> GetOrders
        {
            get
            {
                return ordersDB;
            }
        }
        static public void Add(Order order,int id)
        {
            ordersDB.Add(order);
            order.ID = id;
        }
        static public void ShowAllOrders()
        {
            for (int i = 0; i < ordersDB.Count; i++)
            {
                Console.WriteLine(ordersDB[i]);
            }
        }

    }
}
