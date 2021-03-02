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
                checker.CheckIsNotEmpty(register.InputName()),
                checker.CheckIsNotEmpty(register.InputSurname()),
                checker.CheckIsNotEmpty(register.InputEmail()),
                checker.CheckIsNotEmpty(register.InputLogin()),
                checker.CheckIsNotEmpty(register.InputPassword()));
            UsersLocalDB.Add(registredGuest);
        }
        public bool Enter(ref User user)
        {
            Console.WriteLine("Вхід у систему, введіть логін:");
            string login = Console.ReadLine();
            checker.CheckField(ref login);
            Console.WriteLine("Вхід у систему, введіть пароль:");
            string password = Console.ReadLine();
            checker.CheckField(ref password);
            if (checker.CheckEnter(login, password))
            {
                Console.WriteLine($"Ви увійшли на сайт як {login}");
                user = new RegistredGuest(Rights.RegistredUser);
                (user as RegistredGuest).Login = UsersLocalDB.GetUserlogin(login);
                return true;
            }
            MenuBacker.FailBackMessage();
            return false;
        }
        public bool EnterAsAdmin(ref User user)
        {
            Console.WriteLine("Вхід у систему, введіть логін:");
            string login = Console.ReadLine();
            checker.CheckField(ref login);
            Console.WriteLine("Вхід у систему, введіть пароль:");
            string password = Console.ReadLine();
            checker.CheckField(ref password);
            if (checker.CheckAdminEnter(login, password))
            {
                Console.WriteLine($"Ви увійшли на сайт як {login}");
                user = new Admin(Rights.Admin);
                (user as Admin).Login = UsersLocalDB.GetAdminlogin();
                return true;
            }
            MenuBacker.FailBackMessage();
            return false;
        }


        public void ViewProductsList()
        {
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}){ProductsLocalDB.GetProducts[i]}");
            }
        }
        public void SearchProduct()
        {
            Checker checker = new Checker();
            Console.WriteLine("Введіть назву товару, який хочете знайти");
            string searched = Console.ReadLine();
            checker.CheckField(ref searched);
            for (int i = 0; i < ProductsLocalDB.GetProducts.Count; i++)
            {
                if (searched == ProductsLocalDB.GetProducts[i].Name)
                {
                    Console.WriteLine($"{i + 1}){ProductsLocalDB.GetProducts[i]}");
                }
            }
            Console.ReadKey();
        }
    }
}
