using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Bucket
    {
        List<int> ordersId = new List<int>();
        public void AddOrder(int id)
        {
            for(int i = 0; i < OrderLocalDB.GetOrders.Count; i++)
            {
                if(id == OrderLocalDB.GetOrders[i].ID)
                {
                    ordersId.Add(OrderLocalDB.GetOrders[i].ID);
                }
            }
        }
        public List<int> GetBucket()
        {
            return ordersId;
        }
    }
}
