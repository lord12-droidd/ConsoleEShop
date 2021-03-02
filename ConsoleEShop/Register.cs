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
            Console.WriteLine("Input your name:");
            return Console.ReadLine();
        }

        public string InputSurname()
        {
            Console.WriteLine("Input your surname:");
            return Console.ReadLine();
        }

        public string InputEmail()
        {
            string email;
            while (true)
            {
                Console.WriteLine("Input your email:");
                email = Console.ReadLine();
                if (checker.CheckEmail(email))
                {
                    Console.WriteLine("The inputed email is already in use");
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
                Console.WriteLine("Login:");
                login = Console.ReadLine();
                if (checker.CheckLogin(login))
                {
                    Console.WriteLine("The inputed login is already in use");
                    continue;
                }
                break;
            }
            return login;
        }

        public string InputPassword()
        {
            Console.WriteLine("Password:");
            return Console.ReadLine();
        }
    }
}
