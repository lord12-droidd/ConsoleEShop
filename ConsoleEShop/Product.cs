using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    public class Product
    {
        public int ID { private set; get; }
        public string Name { set; get; }
        public string Category { set; get; }
        public string Description { set; get; }
        public decimal Cost { set; get; }

        public Product(int id, string name, string category, string description, decimal cost)
        {
            ID = id;
            Name = name;
            Category = category;
            Description = description;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"{Name},{Category},{Cost}, ID:{ID}\n{Description}";
        }
    }
}
