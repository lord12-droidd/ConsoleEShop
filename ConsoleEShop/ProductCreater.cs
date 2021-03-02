using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class ProductCreater
    {
        Checker checker = new Checker();

        public int InputId()
        {
            int newID;
            Console.WriteLine("Input ID:");
            while (true)
            {
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (checker.CheckProductId(id))
                    {
                        Console.WriteLine("Such an ID already exists");
                        continue;
                    }
                    newID = id;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("It must be number");
                }
            }
            return newID;
        }

        public string InputName()
        {
            Console.WriteLine("Input the product name:");
            return Console.ReadLine();
        }

        public string InputCategory()
        {
            Console.WriteLine("Input the product category:");
            return Console.ReadLine();
        }

        public string InputDescription()
        {
            Console.WriteLine("Input the product description:");
            return Console.ReadLine();
        }

        public decimal InputCost()
        {
            decimal newCost;
            Console.WriteLine("Input the product cost:");  
            while (true)
            {
                try
                {
                    newCost = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("It must be number");
                }
            }
            return newCost;
        }
    }
}
