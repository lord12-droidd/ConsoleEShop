using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    static class MenuBacker
    {
        public static void BackMessage()
        {
            Console.WriteLine("Успех, нажмите кнопку чтобы вернуться к меню выбора");
            Console.ReadKey();
        }
        public static void FailBackMessage()
        {
            Console.WriteLine("Провал, нажмите кнопку чтобы вернуться к меню выбора");
            Console.ReadKey();
        }
    }
}
