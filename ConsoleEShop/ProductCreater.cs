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
            Console.WriteLine("Введіть ID:");
            while (true)
            {
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (checker.CheckProductId(id))
                    {
                        Console.WriteLine("Такий id вже існує");
                        continue;
                    }
                    newID = id;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число");
                }
            }
            return newID;
        }

        public string InputName()
        {
            Console.WriteLine("Введіть ім'я товару:");
            return Console.ReadLine();
        }

        public string InputCategory()
        {
            Console.WriteLine("Введіть категорію товару:");
            return Console.ReadLine();
        }

        public string InputDescription()
        {
            Console.WriteLine("Введіть опис товару:");
            return Console.ReadLine();
        }

        public decimal InputCost()
        {
            decimal newCost;
            Console.WriteLine("Введіть ціну:");  // 
            while (true)
            {
                try
                {
                    newCost = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число");
                }
            }
            return newCost;
        }
    }
}
