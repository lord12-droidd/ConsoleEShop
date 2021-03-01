using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Register
    {
        Checker checker = new Checker();
        public string InputName()
        {
            Console.WriteLine("Введіть ім'я:");
            return Console.ReadLine();
        }

        public string InputSurname()
        {
            Console.WriteLine("Введіть прізвище:");
            return Console.ReadLine();
        }

        public string InputEmail()
        {
            string email;
            while (true)
            {
                Console.WriteLine("Введіть email:");
                email = Console.ReadLine();
                if (checker.CheckEmail(email))
                {
                    Console.WriteLine("Введений email вже використовується");
                    continue;
                }
                break;
            }
            return email;
        }

        public string InputLogin()
        {
            string login;
            while (true)
            {
                Console.WriteLine("Введіть свій login:");
                login = Console.ReadLine();
                if (checker.CheckLogin(login))
                {
                    Console.WriteLine("Введений login вже використовується");
                    continue;
                }
                break;
            }
            return login;
        }

        public string InputPassword()
        {
            Console.WriteLine("Вигадайте свій пароль:");
            return Console.ReadLine();
        }
    }
}
