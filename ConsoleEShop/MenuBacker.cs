using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class MenuBacker
    {
        public static void BackMessage()
        {
            Console.WriteLine("Success, press the button to return to the selection menu");
            Console.ReadKey();
        }
        public static void FailBackMessage()
        {
            Console.WriteLine("Fail, press the button to return to the selection menu");
            Console.ReadKey();
        }
    }
}
