using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Guest : User, IGuest
    {
        Checker checker = new Checker();
        Register register = new Register();
        public Guest(Rights rights)
        {
            this.rights = rights;
        }
        public void Registration()
        {
            RegistredGuest registredGuest = new RegistredGuest(
                register.InputName(),
                register.InputSurname(),
                register.InputEmail(),
                register.InputLogin(),
                register.InputPassword());
            UsersLocalDB.Add(registredGuest);
        }
        public bool Enter()
        {
            Console.WriteLine("Вхід у систему, введіть логін:");
            string login = Console.ReadLine();  // додати перевірку на пустоту поля
            checker.CheckField(ref login);
            Console.WriteLine("Вхід у систему, введіть пароль:");
            string password = Console.ReadLine(); // додати перевірку на пустоту поля
            checker.CheckField(ref password);
            if (checker.CheckEnter(login, password))
            {
                Console.WriteLine($"Ви увійшли на сайт як {login}");
                return true;
            }
            MenuBacker.FailBackMessage();
            return false;
        }
        public bool EnterAsAdmin(User user)
        {
            Console.WriteLine("Вхід у систему, введіть логін:");
            string login = Console.ReadLine();  // додати перевірку на пустоту поля
            checker.CheckField(ref login);
            Console.WriteLine("Вхід у систему, введіть пароль:");
            string password = Console.ReadLine(); // додати перевірку на пустоту поля
            checker.CheckField(ref password);
            if (checker.CheckAdminEnter(login, password))
            {
                Console.WriteLine($"Ви увійшли на сайт як {login}");
                user.rights = Rights.Admin;
                return true;
            }
            MenuBacker.FailBackMessage();
            return false;
        }


        public void ViewProductsList()
        {
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                Console.WriteLine($"{i}){ProductsLocalDB.GetProducts[i]}");
            }
            //MenuBacker.BackMessage();
        }
        public void SearchProduct()
        {
            Console.WriteLine("Введіть назву товару, який хочете знайти");
            string searched = Console.ReadLine();
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                if (searched == ProductsLocalDB.GetProducts[i].Name)
                {
                    Console.WriteLine($"{i}){ProductsLocalDB.GetProducts[i]}");
                }
            }
            Console.ReadKey();
        }
    }
}
